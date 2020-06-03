using System;
using System.Reflection;
using System.Windows.Forms;

namespace DBClient.Forms.Controls
{
    public partial class DatePickerField : UserControl
    {
        public PropertyInfo Property { get; set; }

        public DatePickerField()
        {
            InitializeComponent();
        }

        public DatePickerField(string displayName, PropertyInfo prop)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            dateTimePicker.Value = DateTime.Now;
        }

        public DatePickerField(string displayName, PropertyInfo prop, string value)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            dateTimePicker.Text = value;
        }

        public string GetValue()
        {
            return dateTimePicker.Text;
        }
    }
}
