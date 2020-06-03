using DBClient.Forms.Controls;
using DBClient.Models.Attributes;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class CreateEditForm<T> : Form where T : class
    {
        private PropertyInfo[] properties;
        private bool IsEditMode = false;
        private T EditingObject;
        private long EditingObjectId;
        public CreateEditForm()
        {
            InitializeComponent();
            this.Text = "Новая запись";
        }

        public CreateEditForm(T item, long id)
        {
            IsEditMode = true;
            EditingObject = item;
            EditingObjectId = id;
            InitializeComponent();
            this.Text = "Изменение записи";
        }

        public async Task LoadAsync()
        {
            properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                var userControl = await GetControl(prop);
                if (userControl != null)
                {
                    flowProperties.Controls.Add(userControl);
                }
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
                //  Если значение свойства bool, то вернуть чекбокс
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
                        var propValue = prop.GetValue(EditingObject);
                        string value;
                        if (propValue != null)
                            value = propValue.ToString();
                        else
                            value = "";
                        userControl = new MaskedTextboxField(displayName, prop, mask, value);
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
                        var propValue = prop.GetValue(EditingObject);
                        string value;
                        if (propValue != null)
                            value = propValue.ToString();
                        else
                            value = "";
                        userControl = new TextboxField(displayName, prop, value);
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

        private void FillInstanceFromControls(T instance)
        {
            var textboxes = flowProperties.Controls.OfType<TextboxField>();
            var comboboxes = flowProperties.Controls.OfType<ComboboxField>();
            var maskedtextboxes = flowProperties.Controls.OfType<MaskedTextboxField>();

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
                    success = await api.AsyncUpdateItem<T>(EditingObject, EditingObjectId);
                }
                else
                {
                    var instance = Activator.CreateInstance<T>();
                    FillInstanceFromControls(instance);
                    success = await api.AsyncPostItem<T>(instance);
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
