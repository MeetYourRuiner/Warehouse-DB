using DBClient.Models;
using DBClient.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class CompanyDetailsForm : Form
    {
        public CompanyDetailsForm()
        {
            InitializeComponent();
        }

        public async Task LoadAsync()
        {
            try
            {
                API api = API.GetInstance();
                var company = await api.GetCompanyDetails();
                tbName.Text = company.Name;
                tbAddress.Text = company.Address;
                mtbINN.Text = company.INN;
                mtbKPP.Text = company.KPP;
                mtbPostalCode.Text = company.PostalCode;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                API api = API.GetInstance();
                var company = new CompanyDetails
                {
                    Name = tbName.Text,
                    Address = tbAddress.Text,
                    INN = mtbINN.Text,
                    KPP = mtbKPP.Text,
                    PostalCode = mtbPostalCode.Text
                };
                await api.PostCompanyDetails(company);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
