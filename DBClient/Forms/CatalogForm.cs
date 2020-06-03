using DBClient.ExtensionMethods;
using DBClient.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class CatalogForm<T> : Form where T : class
    {
        private enum FilterSign
        {
            Contain,
            More,
            Less,
            Equal
        }

        public CatalogForm(string title)
        {
            API api = API.GetInstance();
            var perms = api.CurrentUser.Permissions;
            bool isEmployeeManagementAllowed = (typeof(T) == typeof(Employee) || typeof(T) == typeof(Position)) & !perms.HasFlag(UserPermissions.ManageEmployees);
            if (!perms.HasFlag(UserPermissions.Read))
                throw new Exception("Доступ запрещен");
            if (isEmployeeManagementAllowed)
                throw new Exception("Доступ запрещен");
            InitializeComponent();
            this.Text = title;
        }

        private async Task AsyncGetData()
        {
            API api = API.GetInstance();
            var list = await api.AsyncGetCatalog<T>();
            var dt = list.ToDataTable();
            bindingSource.DataSource = dt;
        }

        public async Task LoadAsync()
        {
            dataGridView.DataSource = bindingSource;
            try
            {
                await AsyncGetData();
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Изменить",
                    Text = "Изменить",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                };
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Удалить",
                    Text = "Удалить",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                };
                dataGridView.DefaultCellStyle.NullValue = "Не указано";
                dataGridView.Columns.Add(editButtonColumn);
                dataGridView.Columns.Add(deleteButtonColumn);

                cbFilterSign.SelectedIndex = (int)FilterSign.Contain;

                cbFilter.DataSource = dataGridView.Columns.OfType<DataGridViewTextBoxColumn>()
                    .Select(c => c.HeaderText)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == dataGridView.Columns["Изменить"].Index)
            {
                try
                {
                    var perms = API.GetInstance().CurrentUser.Permissions;
                    if (!perms.HasFlag(UserPermissions.Write))
                        throw new Exception("Доступ запрещен");
                    var id = (long)dataGridView.Rows[e.RowIndex].Cells["ИД"].Value;
                    var item = (T)(dataGridView.CurrentRow.DataBoundItem as DataRowView).Row[0];
                    CreateEditForm<T> createEditForm = new CreateEditForm<T>(item, id);
                    await createEditForm.LoadAsync();
                    if (createEditForm.ShowDialog() == DialogResult.OK)
                        await AsyncGetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
            else if (e.ColumnIndex == dataGridView.Columns["Удалить"].Index)
            {
                try
                {
                    var perms = API.GetInstance().CurrentUser.Permissions;
                    if (!perms.HasFlag(UserPermissions.Delete))
                        throw new Exception("Доступ запрещен");
                    var id = (long)dataGridView.Rows[e.RowIndex].Cells["ИД"].Value;
                    DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Удаление записи", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        API api = API.GetInstance();
                        await api.AsyncRemoveItem<T>(id);
                        await AsyncGetData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Во время удаления произошла ошибка");
                }
            }
            return;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var perms = API.GetInstance().CurrentUser.Permissions;
                if (!perms.HasFlag(UserPermissions.Write))
                    throw new Exception("Доступ запрещен");
                CreateEditForm<T> createEditForm = new CreateEditForm<T>();
                await createEditForm.LoadAsync();
                if (createEditForm.ShowDialog() == DialogResult.OK)
                    await AsyncGetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            var bs = (BindingSource)dataGridView.DataSource;
            string filter = tbFilter.Text;
            string filterBy = cbFilter.Text;
            string filterString;
            try
            {
                switch (cbFilterSign.SelectedIndex)
                {
                    case (int)FilterSign.Contain:
                        filterString = $"CONVERT([{filterBy}], System.String) like '%{filter}%'";
                        break;
                    case (int)FilterSign.More:
                        filterString = $"[{filterBy}] > {filter}";
                        break;
                    case (int)FilterSign.Less:
                        filterString = $"[{filterBy}] < {filter}";
                        break;
                    case (int)FilterSign.Equal:
                        filterString = $"[{filterBy}] = '{filter}'";
                        break;
                    default:
                        filterString = "";
                        break;
                }
                if (String.IsNullOrWhiteSpace(filter))
                {
                    (bs.DataSource as DataTable).DefaultView.RowFilter = "";
                    return;
                }
                (bs.DataSource as DataTable).DefaultView.RowFilter = filterString;
            }
            catch (Exception)
            {
                (bs.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var dgvColumns = dataGridView.Columns;
            var vscroll = dataGridView.Controls.OfType<VScrollBar>().FirstOrDefault();
            var hscroll = dataGridView.Controls.OfType<HScrollBar>().FirstOrDefault();
            int vscrollWidth = 0;
            if (vscroll != null)
                vscrollWidth = vscroll.Width;
            foreach (DataGridViewColumn item in dgvColumns)
            {
                if (item.Width > 150)
                {
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    item.Width = 150;
                }
            }
            var width = dataGridView.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width) +
                9 +
                vscrollWidth;
            dataGridView.Width = width;
            if (width > tableLayoutPanel.Width)
            {
                Width = width + 22;
                tableLayoutPanel.Width = width;
            }
        }
    }
}
