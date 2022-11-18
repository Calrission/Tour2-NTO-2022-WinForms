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
            this.SuspendLayout();
            // 
            // btnRegions
            // 
            this.btnRegions.Location = new System.Drawing.Point(155, 24);
            this.btnRegions.Name = "btnRegions";
            this.btnRegions.Size = new System.Drawing.Size(189, 23);
            this.btnRegions.TabIndex = 0;
            this.btnRegions.Text = "Регионы";
            this.btnRegions.UseVisualStyleBackColor = true;
            this.btnRegions.Click += new System.EventHandler(this.btnRegions_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(155, 64);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(189, 23);
            this.btnRoles.TabIndex = 1;
            this.btnRoles.Text = "Роли";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnContacts
            // 
            this.btnContacts.Location = new System.Drawing.Point(155, 105);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(189, 23);
            this.btnContacts.TabIndex = 2;
            this.btnContacts.Text = "Контакты";
            this.btnContacts.UseVisualStyleBackColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            // 
            // btnHotels
            // 
            this.btnHotels.Location = new System.Drawing.Point(155, 146);
            this.btnHotels.Name = "btnHotels";
            this.btnHotels.Size = new System.Drawing.Size(189, 23);
            this.btnHotels.TabIndex = 3;
            this.btnHotels.Text = "Отели";
            this.btnHotels.UseVisualStyleBackColor = true;
            this.btnHotels.Click += new System.EventHandler(this.btnHotels_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this.btnHotels);
            this.Controls.Add(this.btnContacts);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnRegions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "Туристическое агенство «АЛЛА»";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRegions;
        private Button btnRoles;
        private Button btnContacts;
        private Button btnHotels;
    }
}