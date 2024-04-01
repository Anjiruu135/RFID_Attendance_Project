namespace RFID_Attendance_Project
{
    partial class PopAttendanceSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopAttendanceSummary));
            this.lblInstrutor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdvisory = new System.Windows.Forms.Label();
            this.dgvSummaryResult = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummaryResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstrutor
            // 
            this.lblInstrutor.BackColor = System.Drawing.Color.Transparent;
            this.lblInstrutor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrutor.ForeColor = System.Drawing.Color.White;
            this.lblInstrutor.Location = new System.Drawing.Point(9, 154);
            this.lblInstrutor.Name = "lblInstrutor";
            this.lblInstrutor.Size = new System.Drawing.Size(172, 50);
            this.lblInstrutor.TabIndex = 3;
            this.lblInstrutor.Text = "Instructor";
            this.lblInstrutor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblInstrutor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblAdvisory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 461);
            this.panel1.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 102);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class Attendance Summary\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdvisory
            // 
            this.lblAdvisory.BackColor = System.Drawing.Color.Transparent;
            this.lblAdvisory.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvisory.ForeColor = System.Drawing.Color.White;
            this.lblAdvisory.Location = new System.Drawing.Point(9, 204);
            this.lblAdvisory.Name = "lblAdvisory";
            this.lblAdvisory.Size = new System.Drawing.Size(172, 32);
            this.lblAdvisory.TabIndex = 4;
            this.lblAdvisory.Text = "Advisory";
            this.lblAdvisory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSummaryResult
            // 
            this.dgvSummaryResult.AllowUserToAddRows = false;
            this.dgvSummaryResult.AllowUserToDeleteRows = false;
            this.dgvSummaryResult.AllowUserToResizeRows = false;
            this.dgvSummaryResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvSummaryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSummaryResult.Location = new System.Drawing.Point(202, 12);
            this.dgvSummaryResult.Name = "dgvSummaryResult";
            this.dgvSummaryResult.ReadOnly = true;
            this.dgvSummaryResult.RowHeadersVisible = false;
            this.dgvSummaryResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSummaryResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummaryResult.Size = new System.Drawing.Size(570, 437);
            this.dgvSummaryResult.TabIndex = 58;
            // 
            // PopAttendanceSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSummaryResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PopAttendanceSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Class Attendance Summary";
            this.Load += new System.EventHandler(this.PopAttendanceSummary_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummaryResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInstrutor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSummaryResult;
        private System.Windows.Forms.Label lblAdvisory;
    }
}