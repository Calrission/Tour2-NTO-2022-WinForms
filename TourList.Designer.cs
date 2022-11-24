namespace TravelCompanyCore
{
    partial class TourList
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dgwTours = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysPerNights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Food = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTours)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(182, 320);
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
            this.btnEdit.Location = new System.Drawing.Point(101, 320);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(20, 320);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dgwTours
            // 
            this.dgwTours.AllowUserToAddRows = false;
            this.dgwTours.AllowUserToDeleteRows = false;
            this.dgwTours.AllowUserToResizeRows = false;
            this.dgwTours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.HotelName,
            this.StartDateTime,
            this.EndDateTime,
            this.DaysPerNights,
            this.Food,
            this.Cost,
            this.Description});
            this.dgwTours.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwTours.Location = new System.Drawing.Point(16, 39);
            this.dgwTours.MultiSelect = false;
            this.dgwTours.Name = "dgwTours";
            this.dgwTours.ReadOnly = true;
            this.dgwTours.RowTemplate.Height = 25;
            this.dgwTours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwTours.Size = new System.Drawing.Size(832, 275);
            this.dgwTours.TabIndex = 12;
            this.dgwTours.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTours_CellDoubleClick);
            this.dgwTours.SelectionChanged += new System.EventHandler(this.dgwTours_SelectionChanged);
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
            this.HotelName.DataPropertyName = "Hotel";
            this.HotelName.HeaderText = "Отель";
            this.HotelName.Name = "HotelName";
            this.HotelName.ReadOnly = true;
            this.HotelName.Width = 150;
            // 
            // StartDateTime
            // 
            this.StartDateTime.DataPropertyName = "StartDateTime";
            this.StartDateTime.HeaderText = "Дата заезда";
            this.StartDateTime.Name = "StartDateTime";
            this.StartDateTime.ReadOnly = true;
            // 
            // EndDateTime
            // 
            this.EndDateTime.DataPropertyName = "EndDateTime";
            this.EndDateTime.HeaderText = "Дата отъезда";
            this.EndDateTime.Name = "EndDateTime";
            this.EndDateTime.ReadOnly = true;
            // 
            // DaysPerNights
            // 
            this.DaysPerNights.DataPropertyName = "DaysPerNights";
            this.DaysPerNights.HeaderText = "Дней\\Ночей";
            this.DaysPerNights.Name = "DaysPerNights";
            this.DaysPerNights.ReadOnly = true;
            // 
            // Food
            // 
            this.Food.DataPropertyName = "Food";
            this.Food.HeaderText = "Вид питания";
            this.Food.Name = "Food";
            this.Food.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Цена";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 50;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Описание";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // TourList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 352);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgwTours);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TourList";
            this.Text = "Список туров";
            this.Load += new System.EventHandler(this.TourList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Button btnCreate;
        private DataGridView dgwTours;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn HotelName;
        private DataGridViewTextBoxColumn StartDateTime;
        private DataGridViewTextBoxColumn EndDateTime;
        private DataGridViewTextBoxColumn DaysPerNights;
        private DataGridViewTextBoxColumn Food;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn Description;
    }
}