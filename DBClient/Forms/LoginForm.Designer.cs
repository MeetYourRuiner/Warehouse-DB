namespace DBClient.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.menuSettings = new System.Windows.Forms.MenuStrip();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeServerAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(111, 47);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(38, 13);
            this.lLogin.TabIndex = 0;
            this.lLogin.Text = "Логин";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(159, 44);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(153, 20);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.Text = "admin";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(159, 77);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(153, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "admin";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(108, 80);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(45, 13);
            this.lPassword.TabIndex = 0;
            this.lPassword.Text = "Пароль";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(175, 115);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSettings});
            this.menuSettings.Location = new System.Drawing.Point(0, 0);
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(347, 24);
            this.menuSettings.TabIndex = 5;
            this.menuSettings.Text = "menuStrip1";
            // 
            // miSettings
            // 
            this.miSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChangeServerAddress});
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(79, 20);
            this.miSettings.Text = "Настройки";
            // 
            // miChangeServerAddress
            // 
            this.miChangeServerAddress.Name = "miChangeServerAddress";
            this.miChangeServerAddress.Size = new System.Drawing.Size(209, 22);
            this.miChangeServerAddress.Text = "Изменить адрес сервера";
            this.miChangeServerAddress.Click += new System.EventHandler(this.miChangeServerAddress_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DBClient.Properties.Resources.warehouse;
            this.pictureBox1.Location = new System.Drawing.Point(35, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 74);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 182);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.menuSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuSettings;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.menuSettings.ResumeLayout(false);
            this.menuSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.MenuStrip menuSettings;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miChangeServerAddress;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

