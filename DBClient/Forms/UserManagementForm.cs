using DBClient.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class UserManagementForm : Form
    {
        private bool IsCreateMode = false;
        public UserManagementForm()
        {
            InitializeComponent();
        }

        public async Task LoadAsync()
        {
            try
            {
                API api = API.GetInstance();
                var userList = await api.AsyncGetCatalog<User>();
                lbUsers.DataSource = userList;
                lbUsers.SelectedIndex = -1;

                var employeeList = await api.AsyncGetCatalog<Employee>();
                cbEmployee.DataSource = employeeList;
                cbEmployee.DisplayMember = "Display";
                cbEmployee.ValueMember = "Id";
                cbEmployee.SelectedIndex = -1;

                chlbPermissions.SelectedIndex = -1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = (User)lbUsers.SelectedItem;
            if (user == null)
            {
                tbLogin.Clear();
                tbPassword.Clear();
                cbEmployee.ResetText();
                cbEmployee.SelectedIndex = -1;
                for (int i = 0; i <= 4; i++)
                    chlbPermissions.SetItemChecked(i, false);
                return;
            }
            tbLogin.Text = user.Login;
            tbPassword.Text = user.Password;
            if (user.EmployeeId != null)
            {
                cbEmployee.SelectedValue = user.EmployeeId;
            }
            else
            {
                cbEmployee.ResetText();
                cbEmployee.SelectedIndex = -1;
            }
            var perms = user.Permissions;
            if (perms.HasFlag(UserPermissions.Read))
                chlbPermissions.SetItemChecked(0, true);
            if (perms.HasFlag(UserPermissions.Write))
                chlbPermissions.SetItemChecked(1, true);
            if (perms.HasFlag(UserPermissions.Delete))
                chlbPermissions.SetItemChecked(2, true);
            if (perms.HasFlag(UserPermissions.ManageEmployees))
                chlbPermissions.SetItemChecked(3, true);
            if (perms.HasFlag(UserPermissions.ManageUsers))
                chlbPermissions.SetItemChecked(4, true);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            User user;
            if (!IsCreateMode)
            {
                user = (User)lbUsers.SelectedItem;
                if (user == null)
                {
                    return;
                }
            }
            else
            {
                user = new User();
            }

            try
            {
                var permList = chlbPermissions.CheckedIndices;
                UserPermissions perm = UserPermissions.None;
                foreach (var item in permList)
                {
                    switch (item)
                    {
                        case 0:
                            perm |= UserPermissions.Read;
                            break;
                        case 1:
                            perm |= UserPermissions.Write;
                            break;
                        case 2:
                            perm |= UserPermissions.Delete;
                            break;
                        case 3:
                            perm |= UserPermissions.ManageEmployees;
                            break;
                        case 4:
                            perm |= UserPermissions.ManageUsers;
                            break;
                        default:
                            break;
                    }
                }

                user.Login = tbLogin.Text;
                user.Password = tbPassword.Text;
                user.EmployeeId = (long?)cbEmployee.SelectedValue;
                user.Permissions = perm;

                API api = API.GetInstance();
                bool success;
                if (IsCreateMode)
                    success = await api.AsyncPostItem<User>(user);
                else
                    success = await api.AsyncUpdateItem<User>(user, user.Id);
                if (success)
                {
                    MessageBox.Show("Сохранено");
                    btnCancel_Click(this, new EventArgs());
                    await LoadAsync();
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbUsers.SelectedItem == null)
                {
                    MessageBox.Show("Пользователь не выбран");
                    return;
                }
                var user = (User)lbUsers.SelectedItem;
                DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Удаление записи", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    API api = API.GetInstance();
                    await api.AsyncRemoveItem<User>(user.Id);
                    await LoadAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Во время удаления произошла ошибка");
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            lbUsers.SelectedIndex = -1;
            cbEmployee.SelectedIndex = -1;
            lbUsers.Enabled = false;
            btnCancel.Visible = true;
            IsCreateMode = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cbEmployee.SelectedIndex = -1;
            lbUsers.Enabled = true;
            btnCancel.Visible = false;
            IsCreateMode = false;
        }
    }
}
