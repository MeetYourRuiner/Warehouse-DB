namespace DBClient.Forms
{
    partial class VATForm
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
            this.lVAT = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.mtbVAT = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lVAT
            // 
            this.lVAT.AutoSize = true;
            this.lVAT.Location = new System.Drawing.Point(44, 16);
            this.lVAT.Name = "lVAT";
            this.lVAT.Size = new System.Drawing.Size(70, 13);
            this.lVAT.TabIndex = 1;
            this.lVAT.Text = "Ставка НДС";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(110, 48);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // mtbVAT
            // 
            this.mtbVAT.Location = new System.Drawing.Point(120, 13);
            this.mtbVAT.Mask = "00.9%";
            this.mtbVAT.Name = "mtbVAT";
            this.mtbVAT.Size = new System.Drawing.Size(65, 20);
            this.mtbVAT.TabIndex = 3;
            // 
            // VATForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 83);
            this.Controls.Add(this.mtbVAT);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lVAT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VATForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменить ставку НДС";
            this.Load += new System.EventHandler(this.VATForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lVAT;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.MaskedTextBox mtbVAT;
    }
}