namespace TravelCompanyCore
{
    partial class ieTourOrderList
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
            this.dgwTourOrders = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TourStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.comboxPayType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bthSearch = new System.Windows.Forms.Button();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTourOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwTourOrders
            // 
            this.dgwTourOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTourOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Client,
            this.PaymentType,
            this.Cost,
            this.TourStatus,
            this.StatusId});
            this.dgwTourOrders.Location = new System.Drawing.Point(14, 47);
            this.dgwTourOrders.Name = "dgwTourOrders";
            this.dgwTourOrders.RowTemplate.Height = 25;
            this.dgwTourOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwTourOrders.Size = new System.Drawing.Size(951, 191);
            this.dgwTourOrders.TabIndex = 0;
            this.dgwTourOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTourOrders_CellDoubleClick);
            this.dgwTourOrders.SelectionChanged += new System.EventHandler(this.dgwTourOrders_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Клиент";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.Width = 300;
            // 
            // PaymentType
            // 
            this.PaymentType.DataPropertyName = "PaymentType";
            this.PaymentType.HeaderText = "Вид оплаты";
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "TotalCost";
            this.Cost.HeaderText = "Стоимость заказа";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // TourStatus
            // 
            this.TourStatus.DataPropertyName = "StatusWitnReasonDescription";
            this.TourStatus.HeaderText = "Статус";
            this.TourStatus.Name = "TourStatus";
            this.TourStatus.ReadOnly = true;
            // 
            // StatusId
            // 
            this.StatusId.DataPropertyName = "TourOrderStatusId";
            this.StatusId.HeaderText = "StatusId";
            this.StatusId.Name = "StatusId";
            this.StatusId.ReadOnly = true;
            this.StatusId.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(176, 248);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(95, 248);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(14, 248);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 16;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Enabled = false;
            this.btnChangeStatus.Location = new System.Drawing.Point(257, 248);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(75, 23);
            this.btnChangeStatus.TabIndex = 19;
            this.btnChangeStatus.Text = "Статус...";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // comboxPayType
            // 
            this.comboxPayType.DisplayMember = "Name";
            this.comboxPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxPayType.FormattingEnabled = true;
            this.comboxPayType.Location = new System.Drawing.Point(560, 13);
            this.comboxPayType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboxPayType.Name = "comboxPayType";
            this.comboxPayType.Size = new System.Drawing.Size(135, 23);
            this.comboxPayType.TabIndex = 151;
            this.comboxPayType.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 150;
            this.label2.Text = "Вид оплаты";
            // 
            // bthSearch
            // 
            this.bthSearch.Location = new System.Drawing.Point(888, 13);
            this.bthSearch.Name = "bthSearch";
            this.bthSearch.Size = new System.Drawing.Size(77, 23);
            this.bthSearch.TabIndex = 149;
            this.bthSearch.Text = "Поиск";
            this.bthSearch.UseVisualStyleBackColor = true;
            this.bthSearch.Click += new System.EventHandler(this.bthSearch_Click);
            // 
            // txtSearchString
            // 
            this.txtSearchString.AccessibleDescription = "";
            this.txtSearchString.Location = new System.Drawing.Point(65, 12);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.PlaceholderText = "Введите часть Названия клиента";
            this.txtSearchString.Size = new System.Drawing.Size(409, 23);
            this.txtSearchString.TabIndex = 148;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 147;
            this.label1.Text = "Фильтр";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DisplayMember = "Name";
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(754, 13);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(119, 23);
            this.comboBoxStatus.TabIndex = 153;
            this.comboBoxStatus.ValueMember = "Id";
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(705, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 152;
            this.label3.Text = "Статус";
            // 
            // ieTourOrderList
            // 
            this.AcceptButton = this.bthSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 281);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboxPayType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bthSearch);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgwTourOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ieTourOrderList";
            this.Text = "Список заказов";
            this.Load += new System.EventHandler(this.ieTourOrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTourOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgwTourOrders;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnCreate;
        private Button btnChangeStatus;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Client;
        private DataGridViewTextBoxColumn PaymentType;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn TourStatus;
        private DataGridViewTextBoxColumn StatusId;
        private ComboBox comboxPayType;
        private Label label2;
        private Button bthSearch;
        private TextBox txtSearchString;
        private Label label1;
        private ComboBox comboBoxStatus;
        private Label label3;
    }
}