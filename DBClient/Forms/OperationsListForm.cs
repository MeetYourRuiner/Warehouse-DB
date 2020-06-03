using DBClient.ExtensionMethods;
using DBClient.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBClient.Forms
{
    public partial class OperationsListForm<OperationType, ContentType> : Form
        where OperationType : class
        where ContentType : class
    {
        private int CurrentRow { get; set; } = -1;

        private enum FilterSign
        {
            Contain,
            More,
            Less,
            Equal
        }

        public OperationsListForm(string title)
        {
            API api = API.GetInstance();
            var perms = api.CurrentUser.Permissions;
            if (!perms.HasFlag(UserPermissions.Read))
                throw new Exception("Доступ запрещен");
            InitializeComponent();
            this.Text = title;
        }

        private async Task AsyncGetData()
        {
            API api = API.GetInstance();
            var list = await api.AsyncGetCatalog<OperationType>();
            var dt = list.ToDataTable();
            bsOperations.DataSource = dt;
        }

        public async Task LoadAsync()
        {
            dgvOpList.DataSource = bsOperations;
            dgvDetailList.DataSource = bsDetails;
            var dtTemplate = new List<ContentType>().GetDataTableTemplate();
            bsDetails.DataSource = dtTemplate;
            try
            {
                await AsyncGetData();
                FillDetailsTable();
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
                dgvOpList.DefaultCellStyle.NullValue = "Не указано";
                dgvOpList.Columns.Add(editButtonColumn);
                dgvOpList.Columns.Add(deleteButtonColumn);

                cbFilterSign.SelectedIndex = (int)FilterSign.Contain;

                var filterColumnList = dgvOpList.Columns.OfType<DataGridViewTextBoxColumn>()
                    .Select(c => c.HeaderText)
                    .ToList();
                filterColumnList.AddRange(dgvOpList.Columns.OfType<DataGridViewCheckBoxColumn>()
                    .Select(c => c.HeaderText)
                    .ToList());
                cbFilter.DataSource = filterColumnList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }


        private async void dgvOpList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOpList.Columns["Изменить"].Index)
            {
                if (typeof(OperationType) == typeof(Shipment))
                {
                    MessageBox.Show("Для изменения удалите и создайте новую запись");
                    return;
                }
                try
                {
                    var perms = API.GetInstance().CurrentUser.Permissions;
                    if (!perms.HasFlag(UserPermissions.Write))
                        throw new Exception("Доступ запрещен");
                    var id = (long)dgvOpList.Rows[e.RowIndex].Cells["ИД"].Value;
                    var item = (OperationType)(dgvOpList.CurrentRow.DataBoundItem as DataRowView).Row[0];
                    OperationCreateEditForm<OperationType, ContentType> createEditForm = new OperationCreateEditForm<OperationType, ContentType>(item, id);
                    await createEditForm.LoadAsync();
                    if (createEditForm.ShowDialog() == DialogResult.OK)
                    {
                        await AsyncGetData();
                        FillDetailsTable();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
            else if (e.ColumnIndex == dgvOpList.Columns["Удалить"].Index)
            {
                try
                {
                    var perms = API.GetInstance().CurrentUser.Permissions;
                    if (!perms.HasFlag(UserPermissions.Delete))
                        throw new Exception("Доступ запрещен");
                    var id = (long)dgvOpList.Rows[e.RowIndex].Cells["ИД"].Value;
                    DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Удаление записи", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        API api = API.GetInstance();
                        await api.AsyncRemoveItem<OperationType>(id);
                        await AsyncGetData();
                        FillDetailsTable();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Во время удаления произошла ошибка");
                }
            }
            else
            {
                FillDetailsTable();
            }
        }

        private void FillDetailsTable()
        {
            var row = dgvOpList.CurrentRow;
            if (row != null)
            {
                var rowIndex = row.Index;
                if (rowIndex < 0 || rowIndex == CurrentRow)
                    return;
                var item = (OperationType)(row.DataBoundItem as DataRowView).Row[0];
                var className = typeof(OperationType).Name;
                var listProperty = typeof(OperationType).GetProperty(className + "Products");
                var list = (List<ContentType>)listProperty.GetValue(item);
                var dt = (DataTable)bsDetails.DataSource;
                dt.Rows.Clear();
                list.FillDataTable(dt);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var perms = API.GetInstance().CurrentUser.Permissions;
                if (!perms.HasFlag(UserPermissions.Write))
                    throw new Exception("Доступ запрещен");
                OperationCreateEditForm<OperationType, ContentType> createEditForm = new OperationCreateEditForm<OperationType, ContentType>();
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
            var bs = (BindingSource)dgvOpList.DataSource;
            string filter = mtbFilter.Text;
            string filterBy = cbFilter.Text;
            string filterString;

            switch (filterBy)
            {
                case "Дата":
                    dtpFilter.Visible = true;
                    mtbFilter.Visible = false;
                    chbFilter.Visible = false;

                    filter = $"#{dtpFilter.Value:MM.dd.yyyy}#";
                    break;
                case "Выполнен":
                    cbFilterSign.SelectedIndex = (int)FilterSign.Equal;
                    cbFilterSign.Enabled = false;

                    mtbFilter.Visible = false;
                    dtpFilter.Visible = false;
                    chbFilter.Visible = true;

                    filter = chbFilter.Checked.ToString();
                    break;
                default:
                    mtbFilter.Mask = null;
                    cbFilterSign.Enabled = true;

                    mtbFilter.Visible = true;
                    chbFilter.Visible = false;
                    dtpFilter.Visible = false;

                    break;
            }

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
                        if (filterBy == "Дата")
                            filterString = $"[{filterBy}] = {filter}";
                        else
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

        private void dgvDetailList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var columns = tableLayoutPanel.ColumnStyles;
            var opListColumns = dgvOpList.Columns;
            var detListColumns = dgvDetailList.Columns;
            foreach (DataGridViewColumn col in opListColumns)
            {
                if (col.Width > 150)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = 150;
                }
            }
            foreach (DataGridViewColumn col in detListColumns)
            {
                if (col.Width > 150)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Width = 150;
                }
            }
            var opWidth = dgvOpList.Columns.Cast<DataGridViewColumn>()
                    .Sum(c => c.Width) + 9;
            var detWidth = dgvDetailList.Columns.Cast<DataGridViewColumn>()
                    .Sum(c => c.Width) + 9;
            columns[0].Width = opWidth;
            columns[1].Width = detWidth;
            dgvDetailList.Width = detWidth;
            Width = detWidth + opWidth + 16;
            tableLayoutPanel.Width = detWidth + opWidth;
        }
    }
}
