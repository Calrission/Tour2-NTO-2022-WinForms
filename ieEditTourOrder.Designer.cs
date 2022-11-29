namespace TravelCompanyCore
{
    partial class ieEditTourOrder
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgwTourOrderItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TourName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.comboClients = new System.Windows.Forms.ComboBox();
            this.comboPaymentType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTourOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Вид оплаты";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgwTourOrderItems);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(21, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 256);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Туры, включённые в Заказ";
            // 
            // dgwTourOrderItems
            // 
            this.dgwTourOrderItems.AllowUserToAddRows = false;
            this.dgwTourOrderItems.AllowUserToDeleteRows = false;
            this.dgwTourOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTourOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TourName,
            this.Cost});
            this.dgwTourOrderItems.Location = new System.Drawing.Point(18, 26);
            this.dgwTourOrderItems.MultiSelect = false;
            this.dgwTourOrderItems.Name = "dgwTourOrderItems";
            this.dgwTourOrderItems.RowTemplate.Height = 25;
            this.dgwTourOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwTourOrderItems.Size = new System.Drawing.Size(726, 178);
            this.dgwTourOrderItems.TabIndex = 8;
            this.dgwTourOrderItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTourOrderItems_CellValueChanged);
            this.dgwTourOrderItems.SelectionChanged += new System.EventHandler(this.dgwTourOrderItems_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ИД";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // TourName
            // 
            this.TourName.DataPropertyName = "Tour";
            this.TourName.HeaderText = "Тур";
            this.TourName.Name = "TourName";
            this.TourName.ReadOnly = true;
            this.TourName.Width = 400;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Стоимость";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 90;
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(117, 218);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(96, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Удалить...";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 218);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboClients
            // 
            this.comboClients.DisplayMember = "Name";
            this.comboClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClients.FormattingEnabled = true;
            this.comboClients.Location = new System.Drawing.Point(72, 29);
            this.comboClients.Name = "comboClients";
            this.comboClients.Size = new System.Drawing.Size(319, 23);
            this.comboClients.TabIndex = 5;
            this.comboClients.ValueMember = "Id";
            // 
            // comboPaymentType
            // 
            this.comboPaymentType.DisplayMember = "Name";
            this.comboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPaymentType.FormattingEnabled = true;
            this.comboPaymentType.Location = new System.Drawing.Point(498, 29);
            this.comboPaymentType.Name = "comboPaymentType";
            this.comboPaymentType.Size = new System.Drawing.Size(284, 23);
            this.comboPaymentType.TabIndex = 6;
            this.comboPaymentType.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Общая стоимость заказа, руб";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTotalCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCost.Location = new System.Drawing.Point(196, 327);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(45, 15);
            this.lblTotalCost.TabIndex = 8;
            this.lblTotalCost.Text = "80 000";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(397, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 282;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(316, 349);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 281;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ieEditTourOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 386);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboPaymentType);
            this.Controls.Add(this.comboClients);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ieEditTourOrder";
            this.Text = "Заказ Тура";
            this.Load += new System.EventHandler(this.ieEditTourOrder_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTourOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnRemove;
        private Button btnAdd;
        private ComboBox comboClients;
        private ComboBox comboPaymentType;
        private Label label3;
        private Label lblTotalCost;
        private Button btnCancel;
        private Button btnOK;
        private DataGridView dgwTourOrderItems;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn TourName;
        private DataGridViewTextBoxColumn Cost;
    }
}