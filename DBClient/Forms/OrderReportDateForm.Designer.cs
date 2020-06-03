namespace DBClient.Forms
{
    partial class OrderReportDateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dpFirst = new System.Windows.Forms.DateTimePicker();
            this.dpSecond = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "За период:";
            // 
            // dpFirst
            // 
            this.dpFirst.Location = new System.Drawing.Point(25, 32);
            this.dpFirst.Name = "dpFirst";
            this.dpFirst.Size = new System.Drawing.Size(200, 20);
            this.dpFirst.TabIndex = 1;
            // 
            // dpSecond
            // 
            this.dpSecond.Location = new System.Drawing.Point(25, 60);
            this.dpSecond.Name = "dpSecond";
            this.dpSecond.Size = new System.Drawing.Size(200, 20);
            this.dpSecond.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(150, 88);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Создать";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // OrderReportDateForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 123);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dpSecond);
            this.Controls.Add(this.dpFirst);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OrderReportDateForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание отчета";
            this.Load += new System.EventHandler(this.OrderReportDateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFirst;
        private System.Windows.Forms.DateTimePicker dpSecond;
        private System.Windows.Forms.Button btnOk;
    }
}