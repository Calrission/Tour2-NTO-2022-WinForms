namespace TravelCompanyCore
{
    partial class Reports
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBoxTypeReport = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.btnPrepareReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "";
            this.reportViewer1.Location = new System.Drawing.Point(0, 53);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(914, 546);
            this.reportViewer1.TabIndex = 0;
            // 
            // comboBoxTypeReport
            // 
            this.comboBoxTypeReport.DisplayMember = "Name";
            this.comboBoxTypeReport.FormattingEnabled = true;
            this.comboBoxTypeReport.Location = new System.Drawing.Point(1, 14);
            this.comboBoxTypeReport.Name = "comboBoxTypeReport";
            this.comboBoxTypeReport.Size = new System.Drawing.Size(204, 28);
            this.comboBoxTypeReport.TabIndex = 1;
            this.comboBoxTypeReport.ValueMember = "Id";
            this.comboBoxTypeReport.SelectedValueChanged += new System.EventHandler(this.comboBoxTypeReport_ValueMemberChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Enabled = false;
            this.dateTimePickerStart.Location = new System.Drawing.Point(215, 14);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerStart.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Enabled = false;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(473, 14);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // btnPrepareReport
            // 
            this.btnPrepareReport.Location = new System.Drawing.Point(728, 13);
            this.btnPrepareReport.Name = "btnPrepareReport";
            this.btnPrepareReport.Size = new System.Drawing.Size(186, 29);
            this.btnPrepareReport.TabIndex = 4;
            this.btnPrepareReport.Text = "Сформировать отчёт";
            this.btnPrepareReport.UseVisualStyleBackColor = true;
            this.btnPrepareReport.Click += new System.EventHandler(this.btnPrepareReport_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.btnPrepareReport);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBoxTypeReport);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Reports";
            this.Text = "Отчётность";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ComboBox comboBoxTypeReport;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Button btnPrepareReport;
    }
}