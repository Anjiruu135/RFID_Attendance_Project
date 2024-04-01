namespace RFID_Attendance_Project
{
    partial class PopStudentSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopStudentSummary));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSummaryResult = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Classes_Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Average_Attendance_Percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummaryResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblSection);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 461);
            this.panel1.TabIndex = 3;
            // 
            // lblSection
            // 
            this.lblSection.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.White;
            this.lblSection.Location = new System.Drawing.Point(9, 114);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(172, 163);
            this.lblSection.TabIndex = 3;
            this.lblSection.Text = "Section";
            this.lblSection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 102);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Attendance Summary";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvSummaryResult
            // 
            this.dgvSummaryResult.AllowUserToAddRows = false;
            this.dgvSummaryResult.AllowUserToDeleteRows = false;
            this.dgvSummaryResult.AllowUserToResizeRows = false;
            this.dgvSummaryResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvSummaryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSummaryResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.Fullname,
            this.Section,
            this.Total_Attendance,
            this.Total_Classes_Section,
            this.Average_Attendance_Percentage});
            this.dgvSummaryResult.Location = new System.Drawing.Point(202, 12);
            this.dgvSummaryResult.Name = "dgvSummaryResult";
            this.dgvSummaryResult.ReadOnly = true;
            this.dgvSummaryResult.RowHeadersVisible = false;
            this.dgvSummaryResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSummaryResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummaryResult.Size = new System.Drawing.Size(470, 437);
            this.dgvSummaryResult.TabIndex = 59;
            // 
            // User_ID
            // 
            this.User_ID.DataPropertyName = "User_ID";
            this.User_ID.HeaderText = "User ID";
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            // 
            // Fullname
            // 
            this.Fullname.DataPropertyName = "Fullname";
            this.Fullname.HeaderText = "Fullname";
            this.Fullname.Name = "Fullname";
            this.Fullname.ReadOnly = true;
            this.Fullname.Width = 200;
            // 
            // Section
            // 
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            // 
            // Total_Attendance
            // 
            this.Total_Attendance.DataPropertyName = "Total_Attendance";
            this.Total_Attendance.HeaderText = "Total Attendance";
            this.Total_Attendance.Name = "Total_Attendance";
            this.Total_Attendance.ReadOnly = true;
            this.Total_Attendance.Visible = false;
            // 
            // Total_Classes_Section
            // 
            this.Total_Classes_Section.DataPropertyName = "Total_Classes_Section";
            this.Total_Classes_Section.HeaderText = "Total Classes";
            this.Total_Classes_Section.Name = "Total_Classes_Section";
            this.Total_Classes_Section.ReadOnly = true;
            this.Total_Classes_Section.Visible = false;
            // 
            // Average_Attendance_Percentage
            // 
            this.Average_Attendance_Percentage.DataPropertyName = "Average_Attendance_Percentage";
            this.Average_Attendance_Percentage.HeaderText = "Average_Attendance_Percentage";
            this.Average_Attendance_Percentage.Name = "Average_Attendance_Percentage";
            this.Average_Attendance_Percentage.ReadOnly = true;
            // 
            // PopStudentSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.dgvSummaryResult);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PopStudentSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Students Summary";
            this.Load += new System.EventHandler(this.PopStudentSummary_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummaryResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSummaryResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Classes_Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Average_Attendance_Percentage;
    }
}