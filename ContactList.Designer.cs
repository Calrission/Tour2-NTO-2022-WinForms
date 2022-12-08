namespace TravelCompanyCore
{
    partial class ContactList
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
            this.dgwContacts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatronymicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListOfRoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.bthSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(174, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(93, 320);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 320);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dgwContacts
            // 
            this.dgwContacts.AllowUserToAddRows = false;
            this.dgwContacts.AllowUserToDeleteRows = false;
            this.dgwContacts.AllowUserToResizeRows = false;
            this.dgwContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.LastName,
            this.FirstName,
            this.PatronymicName,
            this.PhoneNumber,
            this.Email,
            this.ListOfRoles});
            this.dgwContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwContacts.Location = new System.Drawing.Point(12, 39);
            this.dgwContacts.MultiSelect = false;
            this.dgwContacts.Name = "dgwContacts";
            this.dgwContacts.ReadOnly = true;
            this.dgwContacts.RowTemplate.Height = 25;
            this.dgwContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwContacts.Size = new System.Drawing.Size(832, 275);
            this.dgwContacts.TabIndex = 8;
            this.dgwContacts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContacts_CellDoubleClick);
            this.dgwContacts.SelectionChanged += new System.EventHandler(this.dgwContacts_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Фамилия";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 150;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // PatronymicName
            // 
            this.PatronymicName.DataPropertyName = "PatronymicName";
            this.PatronymicName.HeaderText = "Отчество";
            this.PatronymicName.Name = "PatronymicName";
            this.PatronymicName.ReadOnly = true;
            this.PatronymicName.Width = 150;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Телефон";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "EmailAddress";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 200;
            // 
            // ListOfRoles
            // 
            this.ListOfRoles.DataPropertyName = "ListOfRoles";
            this.ListOfRoles.HeaderText = "Роли";
            this.ListOfRoles.Name = "ListOfRoles";
            this.ListOfRoles.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Фильтр";
            // 
            // txtSearchString
            // 
            this.txtSearchString.AccessibleDescription = "Введите часть Фамилии или часть Имени или часть Email для поиска по этим реквизит" +
    "ам";
            this.txtSearchString.Location = new System.Drawing.Point(67, 9);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.PlaceholderText = "Введите часть Фамилии или часть Имени или часть Email для поиска по этим реквизит" +
    "ам";
            this.txtSearchString.Size = new System.Drawing.Size(508, 23);
            this.txtSearchString.TabIndex = 13;
            // 
            // bthSearch
            // 
            this.bthSearch.Location = new System.Drawing.Point(581, 9);
            this.bthSearch.Name = "bthSearch";
            this.bthSearch.Size = new System.Drawing.Size(75, 23);
            this.bthSearch.TabIndex = 14;
            this.bthSearch.Text = "Поиск";
            this.bthSearch.UseVisualStyleBackColor = true;
            this.bthSearch.Click += new System.EventHandler(this.bthSearch_Click);
            // 
            // ContactList
            // 
            this.AcceptButton = this.bthSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 354);
            this.Controls.Add(this.bthSearch);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgwContacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ContactList";
            this.Text = "Список контактов";
            this.Load += new System.EventHandler(this.ContactList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Button btnCreate;
        private DataGridView dgwContacts;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn PatronymicName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn ListOfRoles;
        private Label label1;
        private TextBox txtSearchString;
        private Button bthSearch;
    }
}