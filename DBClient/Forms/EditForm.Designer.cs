namespace DBClient.Forms
{
    partial class CreateEditForm<T>
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
            this.flowProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowControls = new System.Windows.Forms.FlowLayoutPanel();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.flowControls.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowProperties
            // 
            this.flowProperties.AutoSize = true;
            this.flowProperties.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowProperties.Location = new System.Drawing.Point(3, 3);
            this.flowProperties.Name = "flowProperties";
            this.flowProperties.Size = new System.Drawing.Size(0, 0);
            this.flowProperties.TabIndex = 0;
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
            this.flowControls.Controls.Add(this.flowProperties);
            this.flowControls.Controls.Add(this.flowButtons);
            this.flowControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowControls.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowControls.Location = new System.Drawing.Point(6, 6);
            this.flowControls.Name = "flowControls";
            this.flowControls.Size = new System.Drawing.Size(164, 26);
            this.flowControls.TabIndex = 3;
            // 
            // flowButtons
            // 
            this.flowButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowButtons.Controls.Add(this.btnDone);
            this.flowButtons.Controls.Add(this.btnCancel);
            this.flowButtons.Location = new System.Drawing.Point(9, 3);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(162, 29);
            this.flowButtons.TabIndex = 4;
            // 
            // CreateEditForm
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(176, 38);
            this.Controls.Add(this.flowControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateEditForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая запись / Изменение";
            this.flowControls.ResumeLayout(false);
            this.flowControls.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowProperties;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowControls;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
    }
}