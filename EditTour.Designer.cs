namespace TravelCompanyCore
{
    partial class EditTour
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
            this.comboFoods = new System.Windows.Forms.ComboBox();
            this.numericCost = new System.Windows.Forms.NumericUpDown();
            this.rtxtTourDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboHotels = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboFoods
            // 
            this.comboFoods.DisplayMember = "Name";
            this.comboFoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFoods.FormattingEnabled = true;
            this.comboFoods.Location = new System.Drawing.Point(119, 332);
            this.comboFoods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboFoods.Name = "comboFoods";
            this.comboFoods.Size = new System.Drawing.Size(427, 28);
            this.comboFoods.TabIndex = 0;
            this.comboFoods.ValueMember = "Id";
            // 
            // numericCost
            // 
            this.numericCost.DecimalPlaces = 2;
            this.numericCost.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericCost.Location = new System.Drawing.Point(119, 387);
            this.numericCost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericCost.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numericCost.Name = "numericCost";
            this.numericCost.Size = new System.Drawing.Size(427, 27);
            this.numericCost.TabIndex = 1;
            // 
            // rtxtTourDescription
            // 
            this.rtxtTourDescription.Location = new System.Drawing.Point(119, 79);
            this.rtxtTourDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtTourDescription.Name = "rtxtTourDescription";
            this.rtxtTourDescription.Size = new System.Drawing.Size(427, 119);
            this.rtxtTourDescription.TabIndex = 147;
            this.rtxtTourDescription.Text = "";
            this.rtxtTourDescription.Validating += new System.ComponentModel.CancelEventHandler(this.rtxtTourDescription_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "Описание";
            // 
            // comboHotels
            // 
            this.comboHotels.DisplayMember = "Name";
            this.comboHotels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHotels.FormattingEnabled = true;
            this.comboHotels.Location = new System.Drawing.Point(119, 27);
            this.comboHotels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboHotels.Name = "comboHotels";
            this.comboHotels.Size = new System.Drawing.Size(427, 28);
            this.comboHotels.TabIndex = 148;
            this.comboHotels.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 149;
            this.label1.Text = "Отель";
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(119, 221);
            this.dateTimeStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(427, 27);
            this.dateTimeStart.TabIndex = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 151;
            this.label3.Text = "Дата заезда";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 153;
            this.label4.Text = "Дата отъезда";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(119, 277);
            this.dateTimeEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(427, 27);
            this.dateTimeEnd.TabIndex = 152;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 154;
            this.label5.Text = "Вид питания";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 155;
            this.label6.Text = "Стоимость";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 447);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 282;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(174, 447);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 31);
            this.btnOK.TabIndex = 281;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 491);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboHotels);
            this.Controls.Add(this.rtxtTourDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericCost);
            this.Controls.Add(this.comboFoods);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditTour";
            this.Text = "Создание/Редактирование тура";
            this.Load += new System.EventHandler(this.EditTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboFoods;
        private NumericUpDown numericCost;
        private RichTextBox rtxtTourDescription;
        private Label label2;
        private ComboBox comboHotels;
        private Label label1;
        private DateTimePicker dateTimeStart;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimeEnd;
        private Label label5;
        private Label label6;
        private Button btnCancel;
        private Button btnOK;
        private ErrorProvider errorProvider1;
    }
}