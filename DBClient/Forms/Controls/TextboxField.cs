using DBClient.Properties;
using System.Reflection;
using System.Windows.Forms;

namespace DBClient.Forms.Controls
{
    public partial class TextboxField : UserControl
    {
        public PropertyInfo Property { get; set; }

        public TextboxField()
        {
            InitializeComponent();
        }

        public TextboxField(string displayName, PropertyInfo prop)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            if (displayName == "НДС")
                textbox.Text = Settings.Default.DefaultVAT.ToString();
        }

        public TextboxField(string displayName, PropertyInfo prop, string value)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            textbox.Text = value;
        }

        public string GetValue()
        {
            return textbox.Text;
        }
    }
}
