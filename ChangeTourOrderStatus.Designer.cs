namespace TravelCompanyCore
{
    partial class ChangeTourOrderStatus
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnRealized = new System.Windows.Forms.RadioButton();
            this.chkHotelConfirmation = new System.Windows.Forms.CheckBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.comboReasons = new System.Windows.Forms.ComboBox();
            this.rbtnPaid = new System.Windows.Forms.RadioButton();
            this.rbtnCancel = new System.Windows.Forms.RadioButton();
            this.rbtnBooking = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnRealized);
            this.groupBox1.Controls.Add(this.chkHotelConfirmation);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.comboReasons);
            this.groupBox1.Controls.Add(this.rbtnPaid);
            this.groupBox1.Controls.Add(this.rbtnCancel);
            this.groupBox1.Controls.Add(this.rbtnBooking);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Смена статуса";
            // 
            // rbtnRealized
            // 
            this.rbtnRealized.AutoSize = true;
            this.rbtnRealized.Location = new System.Drawing.Point(23, 135);
            this.rbtnRealized.Name = "rbtnRealized";
            this.rbtnRealized.Size = new System.Drawing.Size(67, 19);
            this.rbtnRealized.TabIndex = 6;
            this.rbtnRealized.TabStop = true;
            this.rbtnRealized.Text = "Продан";
            this.rbtnRealized.UseVisualStyleBackColor = true;
            this.rbtnRealized.CheckedChanged += new System.EventHandler(this.rbtnRealized_CheckedChanged);
            // 
            // chkHotelConfirmation
            // 
            this.chkHotelConfirmation.AutoSize = true;
            this.chkHotelConfirmation.Location = new System.Drawing.Point(158, 135);
            this.chkHotelConfirmation.Name = "chkHotelConfirmation";
            this.chkHotelConfirmation.Size = new System.Drawing.Size(236, 19);
            this.chkHotelConfirmation.TabIndex = 5;
            this.chkHotelConfirmation.Text = "Бронь номеров подтверждена в отеле";
            this.chkHotelConfirmation.UseVisualStyleBackColor = true;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(152, 71);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(60, 15);
            this.lblReason.TabIndex = 4;
            this.lblReason.Text = "Причина:";
            // 
            // comboReasons
            // 
            this.comboReasons.DisplayMember = "Name";
            this.comboReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReasons.FormattingEnabled = true;
            this.comboReasons.Location = new System.Drawing.Point(218, 68);
            this.comboReasons.Name = "comboReasons";
            this.comboReasons.Size = new System.Drawing.Size(202, 23);
            this.comboReasons.TabIndex = 3;
            this.comboReasons.ValueMember = "Id";
            // 
            // rbtnPaid
            // 
            this.rbtnPaid.AutoSize = true;
            this.rbtnPaid.Location = new System.Drawing.Point(23, 104);
            this.rbtnPaid.Name = "rbtnPaid";
            this.rbtnPaid.Size = new System.Drawing.Size(74, 19);
            this.rbtnPaid.TabIndex = 2;
            this.rbtnPaid.TabStop = true;
            this.rbtnPaid.Text = "Оплачен";
            this.rbtnPaid.UseVisualStyleBackColor = true;
            this.rbtnPaid.CheckedChanged += new System.EventHandler(this.rbtnCheckChanged);
            // 
            // rbtnCancel
            // 
            this.rbtnCancel.AutoSize = true;
            this.rbtnCancel.Location = new System.Drawing.Point(23, 69);
            this.rbtnCancel.Name = "rbtnCancel";
            this.rbtnCancel.Size = new System.Drawing.Size(67, 19);
            this.rbtnCancel.TabIndex = 1;
            this.rbtnCancel.TabStop = true;
            this.rbtnCancel.Text = "Отмена";
            this.rbtnCancel.UseVisualStyleBackColor = true;
            this.rbtnCancel.CheckedChanged += new System.EventHandler(this.rbtnCheckChanged);
            // 
            // rbtnBooking
            // 
            this.rbtnBooking.AutoSize = true;
            this.rbtnBooking.Location = new System.Drawing.Point(23, 35);
            this.rbtnBooking.Name = "rbtnBooking";
            this.rbtnBooking.Size = new System.Drawing.Size(59, 19);
            this.rbtnBooking.TabIndex = 0;
            this.rbtnBooking.TabStop = true;
            this.rbtnBooking.Text = "Бронь";
            this.rbtnBooking.UseVisualStyleBackColor = true;
            this.rbtnBooking.CheckedChanged += new System.EventHandler(this.rbtnCheckChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 282;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(150, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 281;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 283;
            this.label1.Text = "Текущий статус:";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentStatus.Location = new System.Drawing.Point(122, 16);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(40, 15);
            this.lblCurrentStatus.TabIndex = 284;
            this.lblCurrentStatus.Text = "label2";
            // 
            // ChangeTourOrderStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 268);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChangeTourOrderStatus";
            this.Text = "Изменение статуса Заказа";
            this.Load += new System.EventHandler(this.ChangeTourOrderStatus_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbtnPaid;
        private RadioButton rbtnCancel;
        private RadioButton rbtnBooking;
        private CheckBox chkHotelConfirmation;
        private Label lblReason;
        private ComboBox comboReasons;
        private Button btnCancel;
        private Button btnOK;
        private RadioButton rbtnRealized;
        private Label label1;
        private Label lblCurrentStatus;
    }
}