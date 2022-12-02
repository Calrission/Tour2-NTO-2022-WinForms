namespace TravelCompanyCore
{
    partial class StartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegions = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.btnHotels = new System.Windows.Forms.Button();
            this.btnTours = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnTourOrders = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegions
            // 
            this.btnRegions.Location = new System.Drawing.Point(47, 33);
            this.btnRegions.Name = "btnRegions";
            this.btnRegions.Size = new System.Drawing.Size(189, 23);
            this.btnRegions.TabIndex = 0;
            this.btnRegions.Text = "Регионы";
            this.btnRegions.UseVisualStyleBackColor = true;
            this.btnRegions.Click += new System.EventHandler(this.btnRegions_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(47, 73);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(189, 23);
            this.btnRoles.TabIndex = 1;
            this.btnRoles.Text = "Роли";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnContacts
            // 
            this.btnContacts.Location = new System.Drawing.Point(47, 114);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(189, 23);
            this.btnContacts.TabIndex = 2;
            this.btnContacts.Text = "Контакты";
            this.btnContacts.UseVisualStyleBackColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            // 
            // btnHotels
            // 
            this.btnHotels.Location = new System.Drawing.Point(47, 155);
            this.btnHotels.Name = "btnHotels";
            this.btnHotels.Size = new System.Drawing.Size(189, 23);
            this.btnHotels.TabIndex = 3;
            this.btnHotels.Text = "Отели";
            this.btnHotels.UseVisualStyleBackColor = true;
            this.btnHotels.Click += new System.EventHandler(this.btnHotels_Click);
            // 
            // btnTours
            // 
            this.btnTours.Location = new System.Drawing.Point(47, 36);
            this.btnTours.Name = "btnTours";
            this.btnTours.Size = new System.Drawing.Size(189, 23);
            this.btnTours.TabIndex = 4;
            this.btnTours.Text = "Туры";
            this.btnTours.UseVisualStyleBackColor = true;
            this.btnTours.Click += new System.EventHandler(this.btnTours_Click);
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(47, 76);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(189, 23);
            this.btnClients.TabIndex = 5;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnTourOrders
            // 
            this.btnTourOrders.Location = new System.Drawing.Point(47, 117);
            this.btnTourOrders.Name = "btnTourOrders";
            this.btnTourOrders.Size = new System.Drawing.Size(189, 23);
            this.btnTourOrders.TabIndex = 6;
            this.btnTourOrders.Text = "Заказы";
            this.btnTourOrders.UseVisualStyleBackColor = true;
            this.btnTourOrders.Click += new System.EventHandler(this.btnTourOrders_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnContacts);
            this.groupBox1.Controls.Add(this.btnRegions);
            this.groupBox1.Controls.Add(this.btnHotels);
            this.groupBox1.Controls.Add(this.btnRoles);
            this.groupBox1.Location = new System.Drawing.Point(89, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 198);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Справочники";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClients);
            this.groupBox2.Controls.Add(this.btnTours);
            this.groupBox2.Controls.Add(this.btnTourOrders);
            this.groupBox2.Location = new System.Drawing.Point(89, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 167);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Управление продажами";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "Туристическое агенство «АЛЛА»";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRegions;
        private Button btnRoles;
        private Button btnContacts;
        private Button btnHotels;
        private Button btnTours;
        private Button btnClients;
        private Button btnTourOrders;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}