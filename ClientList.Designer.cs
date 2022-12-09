﻿namespace TravelCompanyCore
{
    partial class ClientList
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
            this.dgwClients = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bthSearch = new System.Windows.Forms.Button();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboxClientType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwClients)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(172, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(91, 326);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(10, 326);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dgwClients
            // 
            this.dgwClients.AllowUserToAddRows = false;
            this.dgwClients.AllowUserToDeleteRows = false;
            this.dgwClients.AllowUserToResizeRows = false;
            this.dgwClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ClientName,
            this.ContactName,
            this.PhoneNumber,
            this.TypeClient});
            this.dgwClients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgwClients.Location = new System.Drawing.Point(10, 44);
            this.dgwClients.MultiSelect = false;
            this.dgwClients.Name = "dgwClients";
            this.dgwClients.ReadOnly = true;
            this.dgwClients.RowHeadersWidth = 51;
            this.dgwClients.RowTemplate.Height = 25;
            this.dgwClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwClients.Size = new System.Drawing.Size(832, 275);
            this.dgwClients.TabIndex = 16;
            this.dgwClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwClients_CellDoubleClick);
            this.dgwClients.SelectionChanged += new System.EventHandler(this.dgwClients_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "Name";
            this.ClientName.HeaderText = "Название";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 350;
            // 
            // ContactName
            // 
            this.ContactName.DataPropertyName = "Contact";
            this.ContactName.HeaderText = "Контактное лицо";
            this.ContactName.MinimumWidth = 6;
            this.ContactName.Name = "ContactName";
            this.ContactName.ReadOnly = true;
            this.ContactName.Width = 225;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Телефон";
            this.PhoneNumber.MinimumWidth = 6;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Width = 125;
            // 
            // TypeClient
            // 
            this.TypeClient.DataPropertyName = "ClientType";
            this.TypeClient.HeaderText = "Вид";
            this.TypeClient.MinimumWidth = 6;
            this.TypeClient.Name = "TypeClient";
            this.TypeClient.ReadOnly = true;
            this.TypeClient.Width = 150;
            // 
            // bthSearch
            // 
            this.bthSearch.Location = new System.Drawing.Point(767, 11);
            this.bthSearch.Name = "bthSearch";
            this.bthSearch.Size = new System.Drawing.Size(75, 23);
            this.bthSearch.TabIndex = 22;
            this.bthSearch.Text = "Поиск";
            this.bthSearch.UseVisualStyleBackColor = true;
            this.bthSearch.Click += new System.EventHandler(this.bthSearch_Click);
            // 
            // txtSearchString
            // 
            this.txtSearchString.AccessibleDescription = "";
            this.txtSearchString.Location = new System.Drawing.Point(63, 11);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.PlaceholderText = "Введите часть Названия клиента или Контактного лица";
            this.txtSearchString.Size = new System.Drawing.Size(409, 23);
            this.txtSearchString.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Фильтр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Тип клиента";
            // 
            // comboxClientType
            // 
            this.comboxClientType.DisplayMember = "Name";
            this.comboxClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxClientType.FormattingEnabled = true;
            this.comboxClientType.Location = new System.Drawing.Point(558, 12);
            this.comboxClientType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboxClientType.Name = "comboxClientType";
            this.comboxClientType.Size = new System.Drawing.Size(196, 23);
            this.comboxClientType.TabIndex = 146;
            this.comboxClientType.ValueMember = "Id";
            // 
            // ClientList
            // 
            this.AcceptButton = this.bthSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 358);
            this.Controls.Add(this.comboxClientType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bthSearch);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dgwClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ClientList";
            this.Text = "Список клиентов";
            this.Load += new System.EventHandler(this.ClientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Button btnCreate;
        private DataGridView dgwClients;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn ClientName;
        private DataGridViewTextBoxColumn ContactName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn TypeClient;
        private Button bthSearch;
        private TextBox txtSearchString;
        private Label label1;
        private Label label2;
        private ComboBox comboxClientType;
    }
}