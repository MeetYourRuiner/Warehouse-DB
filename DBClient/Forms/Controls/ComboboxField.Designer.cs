﻿namespace DBClient.Forms.Controls
{
    partial class ComboboxField
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.combobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 6);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 0;
            this.label.Text = "label1";
            // 
            // combobox
            // 
            this.combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox.FormattingEnabled = true;
            this.combobox.Location = new System.Drawing.Point(72, 3);
            this.combobox.Name = "combobox";
            this.combobox.Size = new System.Drawing.Size(165, 21);
            this.combobox.TabIndex = 1;
            this.combobox.SelectedIndexChanged += new System.EventHandler(this.combobox_SelectedIndexChanged);
            // 
            // ComboboxField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combobox);
            this.Controls.Add(this.label);
            this.Name = "ComboboxField";
            this.Size = new System.Drawing.Size(241, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox combobox;
    }
}
