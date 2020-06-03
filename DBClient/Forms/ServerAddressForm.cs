using DBClient.Properties;
using System;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class ServerAddressForm : Form
    {
        public ServerAddressForm()
        {
            InitializeComponent();
        }

        private void ServerAddressForm_Load(object sender, EventArgs e)
        {
            tbAddress.Text = Settings.Default.API;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Settings.Default.API = tbAddress.Text;
            Settings.Default.Save();
            Close();
        }
    }
}
