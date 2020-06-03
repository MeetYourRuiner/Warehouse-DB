using DBClient.Properties;
using System;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class VATForm : Form
    {
        public VATForm()
        {
            InitializeComponent();
        }

        private void VATForm_Load(object sender, EventArgs e)
        {
            mtbVAT.Text = (Settings.Default.DefaultVAT * 100).ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var percent = Convert.ToDecimal(mtbVAT.Text.Replace("%", "")) / 100;
            Settings.Default.DefaultVAT = percent;
            Settings.Default.Save();
            Close();
        }
    }
}
