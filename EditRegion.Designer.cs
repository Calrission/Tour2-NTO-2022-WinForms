namespace TravelCompanyCore
{
    partial class EditRegion
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
            this.txtRegionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtRegionDescription = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRegionNameValidation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // txtRegionName
            // 
            this.txtRegionName.Location = new System.Drawing.Point(110, 12);
            this.txtRegionName.Name = "txtRegionName";
            this.txtRegionName.Size = new System.Drawing.Size(414, 23);
            this.txtRegionName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Описание";
            // 
            // rtxtRegionDescription
            // 
            this.rtxtRegionDescription.Location = new System.Drawing.Point(110, 62);
            this.rtxtRegionDescription.Name = "rtxtRegionDescription";
            this.rtxtRegionDescription.Size = new System.Drawing.Size(414, 90);
            this.rtxtRegionDescription.TabIndex = 3;
            this.rtxtRegionDescription.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblRegionNameValidation
            // 
            this.lblRegionNameValidation.AutoSize = true;
            this.lblRegionNameValidation.ForeColor = System.Drawing.Color.Red;
            this.lblRegionNameValidation.Location = new System.Drawing.Point(111, 40);
            this.lblRegionNameValidation.Name = "lblRegionNameValidation";
            this.lblRegionNameValidation.Size = new System.Drawing.Size(416, 15);
            this.lblRegionNameValidation.TabIndex = 6;
            this.lblRegionNameValidation.Text = "Наименование региона не должно быть короче двух значащих символов";
            // 
            // EditRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 210);
            this.Controls.Add(this.lblRegionNameValidation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtxtRegionDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegionName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditRegion";
            this.Text = "Создание/Редактирование региона";
            this.Load += new System.EventHandler(this.EditRegion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtRegionName;
        private Label label2;
        private RichTextBox rtxtRegionDescription;
        private Button btnOK;
        private Button btnCancel;
        private Label lblRegionNameValidation;
    }
}