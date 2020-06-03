using DBClient.Forms.Controls;
using DBClient.Models;
using DBClient.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class OperationCreateEditForm<OperationType, ContentType> : Form
        where OperationType : class
        where ContentType : class
    {
        private PropertyInfo[] properties;
        private bool IsEditMode = false;
        private OperationType EditingObject;
        private long EditingObjectId;
        public OperationCreateEditForm()
        {
            InitializeComponent();
            this.Text = "Новая запись";
        }

        public OperationCreateEditForm(OperationType item, long id)
        {
            IsEditMode = true;
            EditingObject = item;
            EditingObjectId = id;
            InitializeComponent();
            this.Text = "Изменение записи";
        }

        public async Task LoadAsync()
        {
            API api = API.GetInstance();
            ProductsColumn.DataSource = await api.AsyncGetCatalog<Product>();
            ProductsColumn.DisplayMember = "NameWithId";
            ProductsColumn.ValueMember = "Id";
            QuantityColumn.DataPropertyName = "Quantity";
            if (IsEditMode)
            {
                List<ContentType> productList;
                var operationName = typeof(OperationType).Name;
                var listProp = typeof(OperationType).GetProperty($"{operationName}Products");
                productList = (List<ContentType>)listProp.GetValue(EditingObject);
                var productIdProp = typeof(ContentType).GetProperty("ProductId");
                var quantityProp = typeof(ContentType).GetProperty("Quantity");
                foreach (var product in productList)
                {
                    var productId = productIdProp.GetValue(product);
                    var quantity = quantityProp.GetValue(product);
                    dataGridView.Rows.Add(new object[] { productId, quantity });
                }
            }
            properties = typeof(OperationType).GetProperties();
            foreach (var prop in properties)
            {
                var userControl = await GetControl(prop);
                if (userControl != null)
                {
                    flowProperties.Controls.Add(userControl);
                }
            }
            //
            //  Если это форма для отгрузок, то немного видоизменяется таблица товаров
            //
            if (typeof(OperationType) == typeof(Shipment))
            {
                MaxQuantityColumn.Visible = true;
                ProductsColumn.ReadOnly = true;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                var cbOrder = flowProperties.Controls.OfType<ComboboxField>().FirstOrDefault();
                cbOrder.SelectedIndexChanged = (() =>
                {
                    var order = (Order)cbOrder.GetItem();
                    if (order != null)
                    {
                        var products = order.OrderProducts.Select(op => new { op.ProductId, op.Quantity });
                        var shipments = order.Shipments.SelectMany(s => s.ShipmentProducts);
                        dataGridView.Rows.Clear();
                        foreach (var p in products)
                        {
                            var shippedQuantity = shipments.Where(s => s.ProductId == p.ProductId).Sum(s => s.Quantity);
                            var maxQuantity = p.Quantity - shippedQuantity;
                            dataGridView.Rows.Add(p.ProductId, 0, maxQuantity);
                        }
                    }
                });
                cbOrder.SelectedIndexChanged.Invoke();
            }
        }

        private async Task<Control> GetControl(PropertyInfo prop)
        {
            var ignoreAttr = prop.GetCustomAttribute<IgnoreInFormAttribute>(false);
            var dnAttr = prop.GetCustomAttribute<DisplayNameAttribute>(false);
            var maskAttr = prop.GetCustomAttribute<MaskAttribute>(false);
            //
            //  Игнорировать свойства с соответствующим атрибутом или без имени
            //
            if (ignoreAttr == null & dnAttr != null)
            {
                string displayName = dnAttr.DisplayName;
                UserControl userControl;
                //
                //  Если значения свойства экземпляры другой сущности, то вернуть комбобокс
                //
                if (prop.GetCustomAttribute<RelatedEntityAttribute>(false) != null)
                {
                    if (IsEditMode)
                    {
                        var entityIdProp = EditingObject
                            .GetType()
                            .GetProperty(prop.Name + "Id")
                            .GetValue(EditingObject);
                        if (entityIdProp == null)
                            entityIdProp = 1L;
                        userControl = new ComboboxField(displayName, prop, (long)entityIdProp);
                        await (userControl as ComboboxField).LoadAsync();
                    }
                    else
                    {
                        userControl = new ComboboxField(displayName, prop);
                        await (userControl as ComboboxField).LoadAsync();
                    }
                }
                //
                //  Если значение свойства дата, то вернуть пикер даты
                //
                else if (prop.PropertyType == typeof(DateTime))
                {
                    if (IsEditMode)
                    {
                        var propValue = prop.GetValue(EditingObject).ToString();
                        userControl = new DatePickerField(displayName, prop, propValue);
                    }
                    else
                    {
                        userControl = new DatePickerField(displayName, prop);
                    }
                }
                //
                //  Если значение свойства бул, то вернуть чекбокс
                //
                else if (prop.PropertyType == typeof(bool))
                {
                    if (IsEditMode)
                    {
                        var propValue = (bool)prop.GetValue(EditingObject);
                        userControl = new CheckboxField(displayName, prop, propValue);
                    }
                    else
                    {
                        if (prop.Name != "IsComplete")
                            userControl = new CheckboxField(displayName, prop);
                        else
                            return null;
                    }
                }
                //
                //  Если указан атрибут маски, вернуть текстбокс с маской
                //
                else if (maskAttr != null)
                {
                    var mask = maskAttr.Mask;
                    if (IsEditMode)
                    {
                        var propValue = prop.GetValue(EditingObject).ToString();
                        userControl = new MaskedTextboxField(displayName, prop, mask, propValue);
                    }
                    else
                    {
                        userControl = new MaskedTextboxField(displayName, prop, mask);
                    }
                }
                //
                //  Иначе вернуть обычный текстбокс
                //
                else
                {
                    if (IsEditMode)
                    {
                        var propValue = prop.GetValue(EditingObject).ToString();
                        userControl = new TextboxField(displayName, prop, propValue);
                    }
                    else
                    {
                        userControl = new TextboxField(displayName, prop);
                    }
                }
                return userControl;
            }
            else
            {
                return null;
            }
        }

        private void FillInstanceFromControls(OperationType instance)
        {
            var textboxes = flowProperties.Controls.OfType<TextboxField>();
            var comboboxes = flowProperties.Controls.OfType<ComboboxField>();
            var datepickers = flowProperties.Controls.OfType<DatePickerField>();
            var checkboxes = flowProperties.Controls.OfType<CheckboxField>();
            var maskedtextboxes = flowProperties.Controls.OfType<MaskedTextboxField>();

            foreach (var dp in datepickers)
            {
                try
                {
                    var value = dp.GetValue();
                    var convertedValue = Convert.ChangeType(value, dp.Property.PropertyType);
                    dp.Property.SetValue(instance, convertedValue, null);
                }
                catch (FormatException)
                {
                    throw new FormatException($"Поле {dp.Property.Name} заполнено неверно");
                }
            }

            foreach (var tb in textboxes)
            {
                try
                {
                    var value = tb.GetValue();
                    var convertedValue = Convert.ChangeType(value, tb.Property.PropertyType);
                    tb.Property.SetValue(instance, convertedValue, null);
                }
                catch (FormatException)
                {
                    throw new FormatException($"Поле {tb.Property.Name} заполнено неверно");
                }
            }

            foreach (var cb in comboboxes)
            {
                try
                {
                    var value = cb.GetValue();
                    var entityIdProp = instance.GetType().GetProperty(cb.Property.Name + "Id");
                    entityIdProp.SetValue(instance, value);
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }

            foreach (var cb in checkboxes)
            {
                var value = cb.GetValue();
                cb.Property.SetValue(instance, value, null);
            }

            foreach (var mtb in maskedtextboxes)
            {
                try
                {
                    var value = mtb.GetValue();
                    var convertedValue = Convert.ChangeType(value, mtb.Property.PropertyType);
                    mtb.Property.SetValue(instance, convertedValue, null);
                }
                catch (FormatException)
                {
                    throw new FormatException($"Поле {mtb.Property.Name} заполнено неверно");
                }
            }

            List<ContentType> productList = new List<ContentType>();
            var productIdProp = typeof(ContentType).GetProperty("ProductId");
            var quantityProp = typeof(ContentType).GetProperty("Quantity");
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var product = Activator.CreateInstance<ContentType>();
                long? productId = (long?)row.Cells[0].Value;
                double quantity = Convert.ToDouble(row.Cells[1].Value);
                if (productId > 0 && quantity > 0)
                {
                    productIdProp.SetValue(product, productId);
                    quantityProp.SetValue(product, quantity);
                    productList.Add(product);
                }
            }
            bool isItemsUnique = productList.GroupBy(p => productIdProp.GetValue(p)).All(g => g.Count() == 1);
            if (productList.Count == 0 || !isItemsUnique)
            {
                throw new Exception("Список товаров пуст или заполнен неправильно");
            }
            else
            {
                var operationName = instance.GetType().Name;
                var listProp = instance.GetType().GetProperty($"{operationName}Products");
                listProp.SetValue(instance, productList);
            }
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                API api = API.GetInstance();
                bool success;
                if (IsEditMode)
                {
                    FillInstanceFromControls(EditingObject);
                    success = await api.AsyncUpdateItem<OperationType>(EditingObject, EditingObjectId);
                }
                else
                {
                    var instance = Activator.CreateInstance<OperationType>();
                    FillInstanceFromControls(instance);
                    success = await api.AsyncPostItem<OperationType>(instance);
                }

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    throw new Exception("Ошибка во время сохранения");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
