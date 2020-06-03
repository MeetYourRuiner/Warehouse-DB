using DBClient.Models;
using System;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            API api = new API();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var api = API.GetInstance();
                var user = new User
                {
                    Login = tbLogin.Text,
                    Password = tbPassword.Text
                };

                Cursor.Current = Cursors.WaitCursor;
                btnLogin.Enabled = false;
                var success = await api.AsyncLogin(user);
                btnLogin.Enabled = true;
                Cursor.Current = Cursors.Default;

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                btnLogin.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void miChangeServerAddress_Click(object sender, EventArgs e)
        {
            ServerAddressForm serverAddressForm = new ServerAddressForm();
            serverAddressForm.ShowDialog();
        }
    }
}