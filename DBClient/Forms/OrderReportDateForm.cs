using System;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class OrderReportDateForm : Form
    {
        public OrderReportDateForm()
        {
            InitializeComponent();
        }

        private void OrderReportDateForm_Load(object sender, EventArgs e)
        {
            dpFirst.Value = DateTime.Today.AddDays(-1);
            dpSecond.Value = DateTime.Today;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                await DocumentManager.CreateOrderReport(dpFirst.Value, dpSecond.Value);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
