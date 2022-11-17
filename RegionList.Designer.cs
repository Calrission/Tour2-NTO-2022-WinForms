namespace TravelCompanyCore
{
    partial class RegionList
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
            this.dgwRegions = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRegions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwRegions
            // 
            this.dgwRegions.AllowUserToAddRows = false;
            this.dgwRegions.AllowUserToDeleteRows = false;
            this.dgwRegions.AllowUserToResizeRows = false;
            this.dgwRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRegions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RegionName,
            this.RegionDescription});
            this.dgwRegions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwRegions.Location = new System.Drawing.Point(8, 36);
            this.dgwRegions.MultiSelect = false;
            this.dgwRegions.Name = "dgwRegions";
            this.dgwRegions.ReadOnly = true;
            this.dgwRegions.RowTemplate.Height = 25;
            this.dgwRegions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwRegions.Size = new System.Drawing.Size(761, 275);
            this.dgwRegions.TabIndex = 0;
            this.dgwRegions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRegions_CellDoubleClick);
            this.dgwRegions.SelectionChanged += new System.EventHandler(this.dgwRegions_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // RegionName
            // 
            this.RegionName.DataPropertyName = "Name";
            this.RegionName.HeaderText = "Название";
            this.RegionName.Name = "RegionName";
            this.RegionName.ReadOnly = true;
            this.RegionName.Width = 200;
            // 
            // RegionDescription
            // 
            this.RegionDescription.DataPropertyName = "Description";
            this.RegionDescription.HeaderText = "Описание";
            this.RegionDescription.Name = "RegionDescription";
            this.RegionDescription.ReadOnly = true;
            this.RegionDescription.Width = 500;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(7, 323);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(88, 323);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(169, 323);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RegionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 356);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgwRegions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegionList";
            this.Text = "Справочник регионов";
            this.Load += new System.EventHandler(this.RegionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwRegions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgwRegions;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn RegionName;
        private DataGridViewTextBoxColumn RegionDescription;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
    }
}