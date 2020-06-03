namespace DBClient.Forms
{
    public partial class OperationsListForm<OperationType, ContentType>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.dgvOpList = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.flowFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.cbFilterSign = new System.Windows.Forms.ComboBox();
            this.mtbFilter = new System.Windows.Forms.MaskedTextBox();
            this.chbFilter = new System.Windows.Forms.CheckBox();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.bsOperations = new System.Windows.Forms.BindingSource(this.components);
            this.bsDetails = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpList)).BeginInit();
            this.flowFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 398F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel.Controls.Add(this.dgvDetailList, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.dgvOpList, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnCreate, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.flowFilter, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(912, 488);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.AllowUserToResizeRows = false;
            this.dgvDetailList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDetailList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDetailList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetailList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvDetailList.ColumnHeadersHeight = 32;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailList.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailList.EnableHeadersVisualStyles = false;
            this.dgvDetailList.Location = new System.Drawing.Point(401, 38);
            this.dgvDetailList.MultiSelect = false;
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.ReadOnly = true;
            this.dgvDetailList.RowHeadersVisible = false;
            this.dgvDetailList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetailList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailList.Size = new System.Drawing.Size(508, 447);
            this.dgvDetailList.TabIndex = 9;
            this.dgvDetailList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDetailList_ColumnWidthChanged);
            // 
            // dgvOpList
            // 
            this.dgvOpList.AllowUserToAddRows = false;
            this.dgvOpList.AllowUserToDeleteRows = false;
            this.dgvOpList.AllowUserToResizeRows = false;
            this.dgvOpList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvOpList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOpList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOpList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvOpList.ColumnHeadersHeight = 32;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpList.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvOpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpList.EnableHeadersVisualStyles = false;
            this.dgvOpList.Location = new System.Drawing.Point(3, 38);
            this.dgvOpList.MultiSelect = false;
            this.dgvOpList.Name = "dgvOpList";
            this.dgvOpList.ReadOnly = true;
            this.dgvOpList.RowHeadersVisible = false;
            this.dgvOpList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOpList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpList.Size = new System.Drawing.Size(392, 447);
            this.dgvOpList.TabIndex = 8;
            this.dgvOpList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOpList_CellClick);
            this.dgvOpList.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDetailList_ColumnWidthChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(812, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(97, 29);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Новая запись";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // flowFilter
            // 
            this.flowFilter.Controls.Add(this.cbFilter);
            this.flowFilter.Controls.Add(this.cbFilterSign);
            this.flowFilter.Controls.Add(this.mtbFilter);
            this.flowFilter.Controls.Add(this.chbFilter);
            this.flowFilter.Controls.Add(this.dtpFilter);
            this.flowFilter.Location = new System.Drawing.Point(3, 3);
            this.flowFilter.Name = "flowFilter";
            this.flowFilter.Size = new System.Drawing.Size(385, 29);
            this.flowFilter.TabIndex = 6;
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(3, 3);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 2;
            this.cbFilter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // cbFilterSign
            // 
            this.cbFilterSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterSign.FormattingEnabled = true;
            this.cbFilterSign.Items.AddRange(new object[] {
            "содержит",
            "больше",
            "меньше",
            "равно"});
            this.cbFilterSign.Location = new System.Drawing.Point(130, 3);
            this.cbFilterSign.Name = "cbFilterSign";
            this.cbFilterSign.Size = new System.Drawing.Size(102, 21);
            this.cbFilterSign.TabIndex = 3;
            this.cbFilterSign.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // mtbFilter
            // 
            this.mtbFilter.Location = new System.Drawing.Point(238, 3);
            this.mtbFilter.Name = "mtbFilter";
            this.mtbFilter.Size = new System.Drawing.Size(120, 20);
            this.mtbFilter.TabIndex = 4;
            this.mtbFilter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // chbFilter
            // 
            this.chbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chbFilter.AutoSize = true;
            this.chbFilter.Location = new System.Drawing.Point(364, 3);
            this.chbFilter.Name = "chbFilter";
            this.chbFilter.Size = new System.Drawing.Size(15, 21);
            this.chbFilter.TabIndex = 5;
            this.chbFilter.UseVisualStyleBackColor = true;
            this.chbFilter.Visible = false;
            this.chbFilter.CheckedChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // dtpFilter
            // 
            this.dtpFilter.Location = new System.Drawing.Point(3, 30);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(120, 20);
            this.dtpFilter.TabIndex = 6;
            this.dtpFilter.Visible = false;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // OperationsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 488);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.Name = "OperationsListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "*ЗАКАЗЫ*";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpList)).EndInit();
            this.flowFilter.ResumeLayout(false);
            this.flowFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.BindingSource bsOperations;
        private System.Windows.Forms.FlowLayoutPanel flowFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ComboBox cbFilterSign;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dgvOpList;
        private System.Windows.Forms.BindingSource bsDetails;
        private System.Windows.Forms.MaskedTextBox mtbFilter;
        private System.Windows.Forms.CheckBox chbFilter;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.DataGridView dgvDetailList;
    }
}