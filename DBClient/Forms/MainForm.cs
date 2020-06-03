using DBClient.Models;
using System;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var api = API.GetInstance();
                if (api.CurrentUser.Employee != null)
                    StatusLabel.Text = $"Вы вошли как: {api.CurrentUser.Employee}";
                else
                    StatusLabel.Text = $"Вы вошли как: Пользователь";
                if (!api.CurrentUser.Permissions.HasFlag(UserPermissions.ManageEmployees))
                    miManageUsers.Visible = false;
                else
                    miManageUsers.Visible = true;
                if (!api.CurrentUser.Permissions.HasFlag(UserPermissions.ManageEmployees) && !api.CurrentUser.Permissions.HasFlag(UserPermissions.ManageUsers))
                    miChangeCompanyDetails.Visible = false;
                else
                    miChangeCompanyDetails.Visible = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private async void btnProducts_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Product>("Товары");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSuppliers_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Supplier>("Поставщики");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Customer>("Заказчики");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Employee>("Сотрудники");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnUnits_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Unit>("Единицы измерения");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnPositions_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Position>("Должности");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                var catalogForm = new CatalogForm<Category>("Категории товаров");
                await catalogForm.LoadAsync();
                catalogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void btnSupply_Click(object sender, EventArgs e)
        {
            try
            {
                var opForm = new OperationsListForm<Supply, SupplyProduct>("Поступления");
                await opForm.LoadAsync();
                opForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnShipments_Click(object sender, EventArgs e)
        {
            try
            {
                var opForm = new OperationsListForm<Shipment, ShipmentProduct>("Отгрузки");
                await opForm.LoadAsync();
                opForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                var opForm = new OperationsListForm<Order, OrderProduct>("Заказы");
                await opForm.LoadAsync();
                opForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void miChangeVAT_Click(object sender, EventArgs e)
        {
            VATForm vatForm = new VATForm();
            vatForm.ShowDialog();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            Hide();
            ShowLoginForm();
            Show();
        }

        private async void miManageUsers_Click(object sender, EventArgs e)
        {
            try
            {
                UserManagementForm umForm = new UserManagementForm();
                await umForm.LoadAsync();
                umForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void miProductReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                await DocumentManager.CreateProductReport();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void miOrderReport_Click(object sender, EventArgs e)
        {
            var reportForm = new OrderReportDateForm();
            reportForm.ShowDialog();
        }

        private async void miChangeCompanyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                var companyDetailsForm = new CompanyDetailsForm();
                await companyDetailsForm.LoadAsync();
                companyDetailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void miNewSupplyDoc_Click(object sender, EventArgs e)
        {
            try
            {
                var newDocumentForm = new NewDocumentForm<Supply>();
                await newDocumentForm.LoadAsync();
                newDocumentForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void miNewOrderDoc_Click(object sender, EventArgs e)
        {
            try
            {
                var newDocumentForm = new NewDocumentForm<Order>();
                await newDocumentForm.LoadAsync();
                newDocumentForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void miNewShipmentDoc_Click(object sender, EventArgs e)
        {
            try
            {
                var newDocumentForm = new NewDocumentForm<Shipment>();
                await newDocumentForm.LoadAsync();
                newDocumentForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
