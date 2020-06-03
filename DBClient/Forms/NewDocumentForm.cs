using DBClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class NewDocumentForm<T> : Form where T : class
    {
        public NewDocumentForm()
        {
            InitializeComponent();
        }

        public async Task LoadAsync()
        {
            try
            {
                API api = API.GetInstance();
                List<T> list = await api.AsyncGetCatalog<T>();
                if (list.Count == 0)
                    throw new Exception("В базе нет операций выбранного типа");
                cbOperation.DataSource = list;
            }
            catch
            {
                throw;
            }
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            if (mtbNumber.MaskCompleted)
            {
                int docId = int.Parse(mtbNumber.Text.Trim());
                switch (typeof(T).Name)
                {
                    case "Supply":
                        await DocumentManager.CreateSupplyDocument(docId, cbOperation.SelectedItem);
                        break;
                    case "Order":
                        await DocumentManager.CreateOrderDocument(docId, cbOperation.SelectedItem);
                        break;
                    default:
                        break;
                }
                Close();
            }
            else
            {
                MessageBox.Show("Введите номер документа");
            }
        }
    }
}
