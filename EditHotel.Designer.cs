namespace TravelCompanyCore
{
    partial class EditHotel
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtHotelDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxManager = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 16);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(427, 27);
            this.txtName.TabIndex = 142;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 143;
            this.label1.Text = "Название";
            // 
            // rtxtHotelDescription
            // 
            this.rtxtHotelDescription.Location = new System.Drawing.Point(128, 55);
            this.rtxtHotelDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtHotelDescription.Name = "rtxtHotelDescription";
            this.rtxtHotelDescription.Size = new System.Drawing.Size(427, 119);
            this.rtxtHotelDescription.TabIndex = 145;
            this.rtxtHotelDescription.Text = "";
            this.rtxtHotelDescription.Validating += new System.ComponentModel.CancelEventHandler(this.rtxtHotelDescription_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 144;
            this.label2.Text = "Описание";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 20);
            this.label12.TabIndex = 273;
            this.label12.Text = "+7";
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(152, 183);
            this.mtxtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtPhone.Mask = "(999) 000-0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(403, 27);
            this.mtxtPhone.TabIndex = 272;
            this.mtxtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtPhone_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 274;
            this.label6.Text = "Телефон";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DisplayMember = "Name";
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(128, 221);
            this.comboBoxRegion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(427, 28);
            this.comboBoxRegion.TabIndex = 275;
            this.comboBoxRegion.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 276;
            this.label3.Text = "Регион";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 278;
            this.label4.Text = "Менеджер";
            // 
            // comboBoxManager
            // 
            this.comboBoxManager.DisplayMember = "Fio";
            this.comboBoxManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxManager.FormattingEnabled = true;
            this.comboBoxManager.Location = new System.Drawing.Point(128, 260);
            this.comboBoxManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxManager.Name = "comboBoxManager";
            this.comboBoxManager.Size = new System.Drawing.Size(427, 28);
            this.comboBoxManager.TabIndex = 277;
            this.comboBoxManager.ValueMember = "Id";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 327);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 280;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(205, 327);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 31);
            this.btnOK.TabIndex = 279;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxManager);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rtxtHotelDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "EditHotel";
            this.Text = "Создание/редактирование отеля";
            this.Load += new System.EventHandler(this.EditHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private RichTextBox rtxtHotelDescription;
        private Label label2;
        private Label label12;
        private MaskedTextBox mtxtPhone;
        private Label label6;
        private ComboBox comboBoxRegion;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxManager;
        private Button btnCancel;
        private Button btnOK;
        private ErrorProvider errorProvider1;
    }
}