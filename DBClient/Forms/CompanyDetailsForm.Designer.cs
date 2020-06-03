namespace DBClient.Forms
{
    partial class CompanyDetailsForm
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lAddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.mtbINN = new System.Windows.Forms.MaskedTextBox();
            this.mtbKPP = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(130, 177);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(128, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Сохранить изменения";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(22, 15);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(57, 13);
            this.lName.TabIndex = 3;
            this.lName.Text = "Название";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(93, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(165, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(93, 45);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(165, 20);
            this.tbAddress.TabIndex = 6;
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(22, 48);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(38, 13);
            this.lAddress.TabIndex = 5;
            this.lAddress.Text = "Адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Индекс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ИНН";
            // 
            // mtbPostalCode
            // 
            this.mtbPostalCode.Location = new System.Drawing.Point(93, 78);
            this.mtbPostalCode.Mask = "000000";
            this.mtbPostalCode.Name = "mtbPostalCode";
            this.mtbPostalCode.Size = new System.Drawing.Size(165, 20);
            this.mtbPostalCode.TabIndex = 10;
            // 
            // mtbINN
            // 
            this.mtbINN.Location = new System.Drawing.Point(93, 111);
            this.mtbINN.Mask = "000000000099";
            this.mtbINN.Name = "mtbINN";
            this.mtbINN.Size = new System.Drawing.Size(165, 20);
            this.mtbINN.TabIndex = 11;
            // 
            // mtbKPP
            // 
            this.mtbKPP.Location = new System.Drawing.Point(93, 144);
            this.mtbKPP.Mask = "000000000";
            this.mtbKPP.Name = "mtbKPP";
            this.mtbKPP.Size = new System.Drawing.Size(165, 20);
            this.mtbKPP.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "КПП";
            // 
            // CompanyDetailsForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(270, 209);
            this.Controls.Add(this.mtbKPP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtbINN);
            this.Controls.Add(this.mtbPostalCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.lAddress);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyDetailsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Реквизиты компании";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbPostalCode;
        private System.Windows.Forms.MaskedTextBox mtbINN;
        private System.Windows.Forms.MaskedTextBox mtbKPP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lName;
    }
}