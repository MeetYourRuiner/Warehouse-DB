using System.Reflection;
using System.Windows.Forms;

namespace DBClient.Forms.Controls
{
    public partial class MaskedTextboxField : UserControl
    {
        public PropertyInfo Property { get; set; }

        public MaskedTextboxField()
        {
            InitializeComponent();
        }

        public MaskedTextboxField(string displayName, PropertyInfo prop, string mask)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            maskedTextbox.Mask = mask;
        }

        public MaskedTextboxField(string displayName, PropertyInfo prop, string mask, string value)
        {
            InitializeComponent();
            Property = prop;
            label.Text = displayName;
            maskedTextbox.Mask = mask;
            maskedTextbox.Text = value;
        }

        public string GetValue()
        {
            return maskedTextbox.Text;
        }
    }
}
