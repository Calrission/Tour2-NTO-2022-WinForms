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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TourStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgwTourOrders.Size = new System.Drawing.Size(769, 191);
            this.dgwTourOrders.TabIndex = 0;
            this.dgwTourOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTourOrders_CellDoubleClick);
            this.dgwTourOrders.SelectionChanged += new System.EventHandler(this.dgwTourOrders_SelectionChanged);
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
            // ieTourOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 281);
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
    }
}