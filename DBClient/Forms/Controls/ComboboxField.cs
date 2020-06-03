using DBClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms.Controls
{
    public partial class ComboboxField : UserControl
    {
        public PropertyInfo Property { get; set; }

        public Action SelectedIndexChanged { get; set; }

        private object selectedValue;

        public ComboboxField()
        {
            InitializeComponent();
        }

        public ComboboxField(string displayName, PropertyInfo prop)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            combobox.ValueMember = "Id";
            combobox.DisplayMember = "Display";
            if (prop.PropertyType == typeof(Employee) && API.GetInstance().CurrentUser.EmployeeId != null)
                this.selectedValue = API.GetInstance().CurrentUser.EmployeeId;
        }

        public ComboboxField(string displayName, PropertyInfo prop, long selectedValue)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            combobox.ValueMember = "Id";
            combobox.DisplayMember = "Display";
            this.selectedValue = selectedValue;
        }

        public long? GetValue()
        {
            if (combobox.SelectedValue == null)
                return null;
            var id = (long)combobox.SelectedValue;
            return id;
        }

        public object GetItem()
        {
            if (combobox.SelectedValue == null)
                return null;
            return combobox.SelectedItem;
        }

        public async Task LoadAsync()
        {
            API api = API.GetInstance();
            var method = typeof(API).GetMethod(nameof(API.AsyncGetCatalog));
            var generic = method.MakeGenericMethod(Property.PropertyType);
            dynamic task = generic.Invoke(api, null);

            var result = await task;
            if (Property.PropertyType == typeof(Order))
                result = (result as List<Order>).Where(o => !o.IsComplete).ToList();
            combobox.DataSource = result;
            if (selectedValue != null)
                combobox.SelectedValue = selectedValue;
        }

        private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke();
        }
    }
}
