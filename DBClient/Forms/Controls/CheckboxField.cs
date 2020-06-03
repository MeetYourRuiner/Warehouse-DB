using System.Reflection;
using System.Windows.Forms;

namespace DBClient.Forms.Controls
{
    public partial class CheckboxField : UserControl
    {
        public PropertyInfo Property { get; set; }

        public CheckboxField()
        {
            InitializeComponent();
        }

        public CheckboxField(string displayName, PropertyInfo prop)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
        }

        public CheckboxField(string displayName, PropertyInfo prop, bool value)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            checkBox.Checked = value;
        }

        public bool GetValue()
        {
            return checkBox.Checked;
        }
    }
}
