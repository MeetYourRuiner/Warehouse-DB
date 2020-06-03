namespace DBClient.Forms
{
    partial class MainForm
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeVAT = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeCompanyDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miProductReport = new System.Windows.Forms.ToolStripMenuItem();
            this.miOrderReport = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewSupplyDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewOrderDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.lCatalogs = new System.Windows.Forms.Label();
            this.lOperations = new System.Windows.Forms.Label();
            this.tableLayoutPanelCatalogs = new System.Windows.Forms.TableLayoutPanel();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnPositions = new System.Windows.Forms.Button();
            this.btnUnits = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnShipments = new System.Windows.Forms.Button();
            this.btnSupply = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanelCatalogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 520);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(641, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 17);
            this.StatusLabel.Text = "ФИО; ";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.документыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(641, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChangeVAT,
            this.miChangeCompanyDetails,
            this.miManageUsers,
            this.toolStripSeparator1,
            this.miLogout});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // miChangeVAT
            // 
            this.miChangeVAT.Name = "miChangeVAT";
            this.miChangeVAT.Size = new System.Drawing.Size(248, 22);
            this.miChangeVAT.Text = "Изменить НДС";
            this.miChangeVAT.Click += new System.EventHandler(this.miChangeVAT_Click);
            // 
            // miChangeCompanyDetails
            // 
            this.miChangeCompanyDetails.Name = "miChangeCompanyDetails";
            this.miChangeCompanyDetails.Size = new System.Drawing.Size(248, 22);
            this.miChangeCompanyDetails.Text = "Изменить реквизиты компании";
            this.miChangeCompanyDetails.Click += new System.EventHandler(this.miChangeCompanyDetails_Click);
            // 
            // miManageUsers
            // 
            this.miManageUsers.Name = "miManageUsers";
            this.miManageUsers.Size = new System.Drawing.Size(248, 22);
            this.miManageUsers.Text = "Настройка пользователей";
            this.miManageUsers.Click += new System.EventHandler(this.miManageUsers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // miLogout
            // 
            this.miLogout.Name = "miLogout";
            this.miLogout.Size = new System.Drawing.Size(248, 22);
            this.miLogout.Text = "Выйти из аккаунта";
            this.miLogout.Click += new System.EventHandler(this.miLogout_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miProductReport,
            this.miOrderReport});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // miProductReport
            // 
            this.miProductReport.Name = "miProductReport";
            this.miProductReport.Size = new System.Drawing.Size(297, 22);
            this.miProductReport.Text = "Создать отчёт по остаткам";
            this.miProductReport.Click += new System.EventHandler(this.miProductReport_Click);
            // 
            // miOrderReport
            // 
            this.miOrderReport.Name = "miOrderReport";
            this.miOrderReport.Size = new System.Drawing.Size(297, 22);
            this.miOrderReport.Text = "Создать отчёт по выполненным заказам";
            this.miOrderReport.Click += new System.EventHandler(this.miOrderReport_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewSupplyDoc,
            this.miNewOrderDoc});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // miNewSupplyDoc
            // 
            this.miNewSupplyDoc.Name = "miNewSupplyDoc";
            this.miNewSupplyDoc.Size = new System.Drawing.Size(230, 22);
            this.miNewSupplyDoc.Text = "Новая приходная накладная";
            this.miNewSupplyDoc.Click += new System.EventHandler(this.miNewSupplyDoc_Click);
            // 
            // miNewOrderDoc
            // 
            this.miNewOrderDoc.Name = "miNewOrderDoc";
            this.miNewOrderDoc.Size = new System.Drawing.Size(230, 22);
            this.miNewOrderDoc.Text = "Новый счёт-фактура";
            this.miNewOrderDoc.Click += new System.EventHandler(this.miNewOrderDoc_Click);
            // 
            // lCatalogs
            // 
            this.lCatalogs.AutoSize = true;
            this.lCatalogs.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanelCatalogs.SetColumnSpan(this.lCatalogs, 3);
            this.lCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lCatalogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lCatalogs.Location = new System.Drawing.Point(3, 0);
            this.lCatalogs.Name = "lCatalogs";
            this.lCatalogs.Size = new System.Drawing.Size(474, 20);
            this.lCatalogs.TabIndex = 2;
            this.lCatalogs.Text = "Справочники";
            this.lCatalogs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lOperations
            // 
            this.lOperations.AutoSize = true;
            this.lOperations.BackColor = System.Drawing.SystemColors.Highlight;
            this.lOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lOperations.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lOperations.Location = new System.Drawing.Point(483, 0);
            this.lOperations.Name = "lOperations";
            this.lOperations.Size = new System.Drawing.Size(155, 20);
            this.lOperations.TabIndex = 3;
            this.lOperations.Text = "Операции";
            this.lOperations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelCatalogs
            // 
            this.tableLayoutPanelCatalogs.AutoSize = true;
            this.tableLayoutPanelCatalogs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCatalogs.ColumnCount = 4;
            this.tableLayoutPanelCatalogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCatalogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCatalogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCatalogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnProducts, 0, 1);
            this.tableLayoutPanelCatalogs.Controls.Add(this.lCatalogs, 0, 0);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnSuppliers, 1, 1);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnOrders, 3, 3);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnCustomers, 2, 1);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnPositions, 1, 2);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnUnits, 0, 2);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnCategories, 2, 2);
            this.tableLayoutPanelCatalogs.Controls.Add(this.lOperations, 3, 0);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnShipments, 3, 2);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnSupply, 3, 1);
            this.tableLayoutPanelCatalogs.Controls.Add(this.btnEmployees, 0, 3);
            this.tableLayoutPanelCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCatalogs.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelCatalogs.Name = "tableLayoutPanelCatalogs";
            this.tableLayoutPanelCatalogs.RowCount = 4;
            this.tableLayoutPanelCatalogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCatalogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCatalogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCatalogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCatalogs.Size = new System.Drawing.Size(641, 496);
            this.tableLayoutPanelCatalogs.TabIndex = 3;
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProducts.Image = global::DBClient.Properties.Resources.products;
            this.btnProducts.Location = new System.Drawing.Point(3, 23);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(154, 154);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "Товары";
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuppliers.Image = global::DBClient.Properties.Resources.suppliers;
            this.btnSuppliers.Location = new System.Drawing.Point(163, 23);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(154, 154);
            this.btnSuppliers.TabIndex = 2;
            this.btnSuppliers.Text = "Поставщики";
            this.btnSuppliers.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOrders.Image = global::DBClient.Properties.Resources.orders;
            this.btnOrders.Location = new System.Drawing.Point(483, 343);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(155, 154);
            this.btnOrders.TabIndex = 10;
            this.btnOrders.Text = "Заказы";
            this.btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCustomers.Image = global::DBClient.Properties.Resources.customers;
            this.btnCustomers.Location = new System.Drawing.Point(323, 23);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(154, 154);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "Заказчики";
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnPositions
            // 
            this.btnPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPositions.Image = global::DBClient.Properties.Resources.positions;
            this.btnPositions.Location = new System.Drawing.Point(163, 183);
            this.btnPositions.Name = "btnPositions";
            this.btnPositions.Size = new System.Drawing.Size(154, 154);
            this.btnPositions.TabIndex = 6;
            this.btnPositions.Text = "Должности";
            this.btnPositions.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPositions.UseVisualStyleBackColor = true;
            this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click);
            // 
            // btnUnits
            // 
            this.btnUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnits.Image = global::DBClient.Properties.Resources.units;
            this.btnUnits.Location = new System.Drawing.Point(3, 183);
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.Size = new System.Drawing.Size(154, 154);
            this.btnUnits.TabIndex = 5;
            this.btnUnits.Text = "Единицы измерения";
            this.btnUnits.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnUnits.UseVisualStyleBackColor = true;
            this.btnUnits.Click += new System.EventHandler(this.btnUnits_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCategories.Image = global::DBClient.Properties.Resources.categories;
            this.btnCategories.Location = new System.Drawing.Point(323, 183);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(154, 154);
            this.btnCategories.TabIndex = 7;
            this.btnCategories.Text = "Категории";
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnShipments
            // 
            this.btnShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShipments.Image = global::DBClient.Properties.Resources.shipments;
            this.btnShipments.Location = new System.Drawing.Point(483, 183);
            this.btnShipments.Name = "btnShipments";
            this.btnShipments.Size = new System.Drawing.Size(155, 154);
            this.btnShipments.TabIndex = 8;
            this.btnShipments.Text = "Отгрузки";
            this.btnShipments.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnShipments.UseVisualStyleBackColor = true;
            this.btnShipments.Click += new System.EventHandler(this.btnShipments_Click);
            // 
            // btnSupply
            // 
            this.btnSupply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupply.Image = global::DBClient.Properties.Resources.supply;
            this.btnSupply.Location = new System.Drawing.Point(483, 23);
            this.btnSupply.Name = "btnSupply";
            this.btnSupply.Size = new System.Drawing.Size(155, 154);
            this.btnSupply.TabIndex = 4;
            this.btnSupply.Text = "Поступления";
            this.btnSupply.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSupply.UseVisualStyleBackColor = true;
            this.btnSupply.Click += new System.EventHandler(this.btnSupply_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmployees.Image = global::DBClient.Properties.Resources.employees;
            this.btnEmployees.Location = new System.Drawing.Point(3, 343);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(154, 154);
            this.btnEmployees.TabIndex = 9;
            this.btnEmployees.Text = "Сотрудники";
            this.btnEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(641, 542);
            this.Controls.Add(this.tableLayoutPanelCatalogs);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стартовая страница";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanelCatalogs.ResumeLayout(false);
            this.tableLayoutPanelCatalogs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Label lCatalogs;
        private System.Windows.Forms.Label lOperations;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCatalogs;
        private System.Windows.Forms.Button btnSupply;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnShipments;
        private System.Windows.Forms.Button btnPositions;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnUnits;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.ToolStripMenuItem miChangeVAT;
        private System.Windows.Forms.ToolStripMenuItem miManageUsers;
        private System.Windows.Forms.ToolStripMenuItem miLogout;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miProductReport;
        private System.Windows.Forms.ToolStripMenuItem miOrderReport;
        private System.Windows.Forms.ToolStripMenuItem miChangeCompanyDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miNewSupplyDoc;
        private System.Windows.Forms.ToolStripMenuItem miNewOrderDoc;
    }
}