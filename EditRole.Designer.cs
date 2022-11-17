namespace TravelCompanyCore
{
    partial class EditRole
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
            this.lblRoleNameValidation = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rtxtRoleDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRoleNameValidation
            // 
            this.lblRoleNameValidation.AutoSize = true;
            this.lblRoleNameValidation.ForeColor = System.Drawing.Color.Red;
            this.lblRoleNameValidation.Location = new System.Drawing.Point(111, 37);
            this.lblRoleNameValidation.Name = "lblRoleNameValidation";
            this.lblRoleNameValidation.Size = new System.Drawing.Size(399, 15);
            this.lblRoleNameValidation.TabIndex = 13;
            this.lblRoleNameValidation.Text = "Наименование роли не должно быть короче двух значащих символов";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(189, 164);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rtxtRoleDescription
            // 
            this.rtxtRoleDescription.Location = new System.Drawing.Point(110, 59);
            this.rtxtRoleDescription.Name = "rtxtRoleDescription";
            this.rtxtRoleDescription.Size = new System.Drawing.Size(400, 90);
            this.rtxtRoleDescription.TabIndex = 10;
            this.rtxtRoleDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Описание";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(110, 9);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(400, 23);
            this.txtRoleName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Наименование";
            // 
            // EditRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 203);
            this.Controls.Add(this.lblRoleNameValidation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtxtRoleDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditRole";
            this.Text = "Создание\\редактирование ролей";
            this.Load += new System.EventHandler(this.EditRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblRoleNameValidation;
        private Button btnCancel;
        private Button btnOK;
        private RichTextBox rtxtRoleDescription;
        private Label label2;
        private TextBox txtRoleName;
        private Label label1;
    }
}