namespace DBClient.Forms
{
    partial class OperationCreateEditForm<OperationType, ContentType>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowControls = new System.Windows.Forms.FlowLayoutPanel();
            this.flowButtonsAndProps = new System.Windows.Forms.FlowLayoutPanel();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ProductsColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowControls.SuspendLayout();
            this.flowButtonsAndProps.SuspendLayout();
            this.flowButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flowProperties
            // 
            this.flowProperties.AutoSize = true;
            this.flowProperties.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowProperties.Location = new System.Drawing.Point(3, 3);
            this.flowProperties.Name = "flowProperties";
            this.flowProperties.Size = new System.Drawing.Size(0, 0);
            this.flowProperties.TabIndex = 1;
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Location = new System.Drawing.Point(3, 3);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Готово";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowControls
            // 
            this.flowControls.AutoSize = true;
            this.flowControls.Controls.Add(this.flowButtonsAndProps);
            this.flowControls.Controls.Add(this.dataGridView);
            this.flowControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowControls.Location = new System.Drawing.Point(0, 0);
            this.flowControls.Name = "flowControls";
            this.flowControls.Padding = new System.Windows.Forms.Padding(6);
            this.flowControls.Size = new System.Drawing.Size(455, 160);
            this.flowControls.TabIndex = 3;
            // 
            // flowButtonsAndProps
            // 
            this.flowButtonsAndProps.AutoSize = true;
            this.flowButtonsAndProps.Controls.Add(this.flowProperties);
            this.flowButtonsAndProps.Controls.Add(this.flowButtons);
            this.flowButtonsAndProps.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowButtonsAndProps.Location = new System.Drawing.Point(9, 9);
            this.flowButtonsAndProps.Name = "flowButtonsAndProps";
            this.flowButtonsAndProps.Size = new System.Drawing.Size(168, 41);
            this.flowButtonsAndProps.TabIndex = 6;
            // 
            // flowButtons
            // 
            this.flowButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowButtons.Controls.Add(this.btnDone);
            this.flowButtons.Controls.Add(this.btnCancel);
            this.flowButtons.Location = new System.Drawing.Point(3, 9);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(162, 29);
            this.flowButtons.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductsColumn,
            this.QuantityColumn,
            this.MaxQuantityColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(183, 9);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(240, 150);
            this.dataGridView.TabIndex = 5;
            // 
            // ProductsColumn
            // 
            this.ProductsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductsColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ProductsColumn.HeaderText = "Товар";
            this.ProductsColumn.Name = "ProductsColumn";
            this.ProductsColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.QuantityColumn.HeaderText = "Кол-во";
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.Width = 71;
            // 
            // MaxQuantityColumn
            // 
            this.MaxQuantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.MaxQuantityColumn.HeaderText = "";
            this.MaxQuantityColumn.Name = "MaxQuantityColumn";
            this.MaxQuantityColumn.ReadOnly = true;
            this.MaxQuantityColumn.ToolTipText = "В заказе";
            this.MaxQuantityColumn.Visible = false;
            this.MaxQuantityColumn.Width = 21;
            // 
            // OperationCreateEditForm
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(455, 160);
            this.Controls.Add(this.flowControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OperationCreateEditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая запись / Изменение";
            this.flowControls.ResumeLayout(false);
            this.flowControls.PerformLayout();
            this.flowButtonsAndProps.ResumeLayout(false);
            this.flowButtonsAndProps.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowProperties;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowControls;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowButtonsAndProps;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxQuantityColumn;
    }
}