namespace TravelCompanyCore
{
    partial class EditClient
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
            this.components = new System.ComponentModel.Container();
            this.comboContact = new System.Windows.Forms.ComboBox();
            this.lblContactText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboxClientType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.lbl7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboContact
            // 
            this.comboContact.DisplayMember = "Fio";
            this.comboContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboContact.FormattingEnabled = true;
            this.comboContact.Location = new System.Drawing.Point(146, 98);
            this.comboContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboContact.Name = "comboContact";
            this.comboContact.Size = new System.Drawing.Size(374, 23);
            this.comboContact.TabIndex = 0;
            this.comboContact.ValueMember = "Id";
            this.comboContact.Validating += new System.ComponentModel.CancelEventHandler(this.comboContact_Validating);
            // 
            // lblContactText
            // 
            this.lblContactText.AutoSize = true;
            this.lblContactText.Location = new System.Drawing.Point(10, 98);
            this.lblContactText.Name = "lblContactText";
            this.lblContactText.Size = new System.Drawing.Size(101, 15);
            this.lblContactText.TabIndex = 142;
            this.lblContactText.Text = "Контактное лицо";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 143;
            this.label2.Text = "Наименование";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(146, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(374, 23);
            this.txtName.TabIndex = 144;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 146;
            this.label3.Text = "Вид клиента";
            // 
            // comboxClientType
            // 
            this.comboxClientType.DisplayMember = "Name";
            this.comboxClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxClientType.FormattingEnabled = true;
            this.comboxClientType.Location = new System.Drawing.Point(146, 57);
            this.comboxClientType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboxClientType.Name = "comboxClientType";
            this.comboxClientType.Size = new System.Drawing.Size(374, 23);
            this.comboxClientType.TabIndex = 145;
            this.comboxClientType.ValueMember = "Id";
            this.comboxClientType.SelectedValueChanged += new System.EventHandler(this.comboxClientType_SelectedValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 148;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(189, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 147;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(167, 99);
            this.mtxtPhone.Mask = "(999) 000-0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(353, 23);
            this.mtxtPhone.TabIndex = 149;
            this.mtxtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtPhone_Validating);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(146, 102);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(21, 15);
            this.lbl7.TabIndex = 150;
            this.lbl7.Text = "+7";
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 180);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboxClientType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblContactText);
            this.Controls.Add(this.comboContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "EditClient";
            this.Text = "Создание/Редактирование клиента";
            this.Load += new System.EventHandler(this.EditClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboContact;
        private Label lblContactText;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private ComboBox comboxClientType;
        private Button btnCancel;
        private Button btnOK;
        private ErrorProvider errorProvider1;
        private MaskedTextBox mtxtPhone;
        private Label lbl7;
    }
}