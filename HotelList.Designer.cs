namespace TravelCompanyCore
{
    partial class HotelList
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dgwHotels = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotelListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fakeDataSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboxRegion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bthSearch = new System.Windows.Forms.Button();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwHotels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fakeDataSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(174, 328);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(93, 328);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 328);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dgwHotels
            // 
            this.dgwHotels.AllowUserToAddRows = false;
            this.dgwHotels.AllowUserToDeleteRows = false;
            this.dgwHotels.AllowUserToResizeRows = false;
            this.dgwHotels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwHotels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.HotelName,
            this.Region,
            this.PhoneNumber,
            this.Manager,
            this.Description,
            this.RegionId,
            this.ManagerId});
            this.dgwHotels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwHotels.Location = new System.Drawing.Point(12, 47);
            this.dgwHotels.MultiSelect = false;
            this.dgwHotels.Name = "dgwHotels";
            this.dgwHotels.ReadOnly = true;
            this.dgwHotels.RowTemplate.Height = 25;
            this.dgwHotels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwHotels.Size = new System.Drawing.Size(866, 275);
            this.dgwHotels.TabIndex = 12;
            this.dgwHotels.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwHotels_CellMouseDoubleClick);
            this.dgwHotels.SelectionChanged += new System.EventHandler(this.dgwHotels_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // HotelName
            // 
            this.HotelName.DataPropertyName = "Name";
            this.HotelName.HeaderText = "Название";
            this.HotelName.Name = "HotelName";
            this.HotelName.ReadOnly = true;
            this.HotelName.Width = 150;
            // 
            // Region
            // 
            this.Region.DataPropertyName = "Region";
            this.Region.HeaderText = "Местонахождение";
            this.Region.Name = "Region";
            this.Region.ReadOnly = true;
            this.Region.Width = 200;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Телефон";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            // 
            // Manager
            // 
            this.Manager.DataPropertyName = "Manager";
            this.Manager.HeaderText = "Управляющий";
            this.Manager.Name = "Manager";
            this.Manager.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Описание";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // RegionId
            // 
            this.RegionId.DataPropertyName = "RegionId";
            this.RegionId.HeaderText = "RegionId";
            this.RegionId.Name = "RegionId";
            this.RegionId.ReadOnly = true;
            this.RegionId.Visible = false;
            // 
            // ManagerId
            // 
            this.ManagerId.DataPropertyName = "ManagerId";
            this.ManagerId.HeaderText = "ManagerId";
            this.ManagerId.Name = "ManagerId";
            this.ManagerId.ReadOnly = true;
            this.ManagerId.Visible = false;
            // 
            // comboxRegion
            // 
            this.comboxRegion.DisplayMember = "Name";
            this.comboxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxRegion.FormattingEnabled = true;
            this.comboxRegion.Location = new System.Drawing.Point(593, 13);
            this.comboxRegion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboxRegion.Name = "comboxRegion";
            this.comboxRegion.Size = new System.Drawing.Size(197, 23);
            this.comboxRegion.TabIndex = 151;
            this.comboxRegion.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 150;
            this.label2.Text = "Местонахождение";
            // 
            // bthSearch
            // 
            this.bthSearch.Location = new System.Drawing.Point(802, 12);
            this.bthSearch.Name = "bthSearch";
            this.bthSearch.Size = new System.Drawing.Size(76, 23);
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
            this.txtSearchString.PlaceholderText = "Введите часть Названия отеля";
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
            // HotelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 360);
            this.Controls.Add(this.comboxRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bthSearch);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgwHotels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HotelList";
            this.Text = "Список отелей";
            this.Load += new System.EventHandler(this.HotelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwHotels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fakeDataSourceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Button btnCreate;
        private DataGridView dgwHotels;
        private BindingSource hotelListBindingSource;
        private BindingSource fakeDataSourceBindingSource;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn HotelName;
        private DataGridViewTextBoxColumn Region;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Manager;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn RegionId;
        private DataGridViewTextBoxColumn ManagerId;
        private ComboBox comboxRegion;
        private Label label2;
        private Button bthSearch;
        private TextBox txtSearchString;
        private Label label1;
    }
}