namespace RFID_Attendance_Project.UserControls
{
    partial class UC_UserScanner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtIDBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSubject = new System.Windows.Forms.Label();
            this.TimerSubject = new System.Windows.Forms.Timer(this.components);
            this.lblSchedID = new System.Windows.Forms.Label();
            this.txtInstructorIDBox = new System.Windows.Forms.TextBox();
            this.lblSection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDBox
            // 
            this.txtIDBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIDBox.Enabled = false;
            this.txtIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDBox.Location = new System.Drawing.Point(519, 263);
            this.txtIDBox.Name = "txtIDBox";
            this.txtIDBox.Size = new System.Drawing.Size(400, 38);
            this.txtIDBox.TabIndex = 0;
            this.txtIDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDBox_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 102);
            this.label3.TabIndex = 41;
            this.label3.Text = "Class Attendance\r\n- Instructor Scanner - ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picBox
            // 
            this.picBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBox.BackColor = System.Drawing.Color.White;
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(315, 156);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(175, 175);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 42;
            this.picBox.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(519, 177);
            this.lblName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblName.MinimumSize = new System.Drawing.Size(400, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(400, 25);
            this.lblName.TabIndex = 43;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(519, 202);
            this.lblStatus.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblStatus.MinimumSize = new System.Drawing.Size(400, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 24);
            this.lblStatus.TabIndex = 44;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Location = new System.Drawing.Point(519, 226);
            this.lblTime.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblTime.MinimumSize = new System.Drawing.Size(400, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(400, 20);
            this.lblTime.TabIndex = 45;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 491);
            this.panel1.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1034, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 491);
            this.panel2.TabIndex = 47;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubject.Location = new System.Drawing.Point(519, 57);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(400, 39);
            this.lblSubject.TabIndex = 48;
            this.lblSubject.Text = "No Schedule at This Time...";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TimerSubject
            // 
            this.TimerSubject.Interval = 1000;
            this.TimerSubject.Tick += new System.EventHandler(this.SubjectTimer_Tick);
            // 
            // lblSchedID
            // 
            this.lblSchedID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSchedID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSchedID.Location = new System.Drawing.Point(315, 57);
            this.lblSchedID.MaximumSize = new System.Drawing.Size(175, 96);
            this.lblSchedID.Name = "lblSchedID";
            this.lblSchedID.Size = new System.Drawing.Size(175, 96);
            this.lblSchedID.TabIndex = 49;
            this.lblSchedID.Text = "Sched ID";
            this.lblSchedID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInstructorIDBox
            // 
            this.txtInstructorIDBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInstructorIDBox.Enabled = false;
            this.txtInstructorIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstructorIDBox.Location = new System.Drawing.Point(519, 263);
            this.txtInstructorIDBox.Name = "txtInstructorIDBox";
            this.txtInstructorIDBox.Size = new System.Drawing.Size(400, 38);
            this.txtInstructorIDBox.TabIndex = 50;
            this.txtInstructorIDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInstructorIDBox_KeyDown);
            // 
            // lblSection
            // 
            this.lblSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSection.Location = new System.Drawing.Point(315, 334);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(175, 39);
            this.lblSection.TabIndex = 51;
            this.lblSection.Text = "Section";
            this.lblSection.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UC_UserScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.txtInstructorIDBox);
            this.Controls.Add(this.lblSchedID);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.txtIDBox);
            this.Name = "UC_UserScanner";
            this.Size = new System.Drawing.Size(1234, 491);
            this.Load += new System.EventHandler(this.UC_UserScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Timer TimerSubject;
        private System.Windows.Forms.Label lblSchedID;
        private System.Windows.Forms.TextBox txtInstructorIDBox;
        private System.Windows.Forms.Label lblSection;
    }
}
