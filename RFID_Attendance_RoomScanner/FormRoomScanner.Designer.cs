namespace RFID_Attendance_RoomScanner
{
    partial class FormRoomScanner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoomScanner));
            this.txtIDBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.TimerSubject = new System.Windows.Forms.Timer(this.components);
            this.lblSection = new System.Windows.Forms.Label();
            this.txtInstructorIDBox = new System.Windows.Forms.TextBox();
            this.lblSchedID = new System.Windows.Forms.Label();
            this.btnSelectRoom = new System.Windows.Forms.Button();
            this.lblRoom = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
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
            this.txtIDBox.TabIndex = 52;
            this.txtIDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDBox_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 102);
            this.label3.TabIndex = 41;
            this.label3.Text = "Class Attendance\r\n- Room Scanner - ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubject.Location = new System.Drawing.Point(519, 57);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(400, 39);
            this.lblSubject.TabIndex = 59;
            this.lblSubject.Text = "No Schedule at This Time...";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1034, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 561);
            this.panel2.TabIndex = 58;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblRoom);
            this.panel1.Controls.Add(this.btnSelectRoom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 561);
            this.panel1.TabIndex = 57;
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
            this.lblTime.TabIndex = 56;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblStatus.TabIndex = 55;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblName.TabIndex = 54;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.picBox.TabIndex = 53;
            this.picBox.TabStop = false;
            // 
            // TimerSubject
            // 
            this.TimerSubject.Interval = 1000;
            this.TimerSubject.Tick += new System.EventHandler(this.SubjectTimer_Tick);
            // 
            // lblSection
            // 
            this.lblSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSection.Location = new System.Drawing.Point(315, 334);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(175, 39);
            this.lblSection.TabIndex = 62;
            this.lblSection.Text = "Section";
            this.lblSection.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInstructorIDBox
            // 
            this.txtInstructorIDBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInstructorIDBox.Enabled = false;
            this.txtInstructorIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstructorIDBox.Location = new System.Drawing.Point(519, 263);
            this.txtInstructorIDBox.Name = "txtInstructorIDBox";
            this.txtInstructorIDBox.Size = new System.Drawing.Size(400, 38);
            this.txtInstructorIDBox.TabIndex = 61;
            this.txtInstructorIDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInstructorIDBox_KeyDown);
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
            this.lblSchedID.TabIndex = 60;
            this.lblSchedID.Text = "Sched ID";
            this.lblSchedID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSelectRoom
            // 
            this.btnSelectRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSelectRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectRoom.ForeColor = System.Drawing.Color.White;
            this.btnSelectRoom.Location = new System.Drawing.Point(7, 519);
            this.btnSelectRoom.Name = "btnSelectRoom";
            this.btnSelectRoom.Size = new System.Drawing.Size(185, 30);
            this.btnSelectRoom.TabIndex = 42;
            this.btnSelectRoom.Text = "Select Room";
            this.btnSelectRoom.UseVisualStyleBackColor = false;
            this.btnSelectRoom.Click += new System.EventHandler(this.btnSelectRoom_Click);
            // 
            // lblRoom
            // 
            this.lblRoom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRoom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.ForeColor = System.Drawing.Color.White;
            this.lblRoom.Location = new System.Drawing.Point(7, 156);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(190, 175);
            this.lblRoom.TabIndex = 43;
            this.lblRoom.Text = "ROOM\r\n";
            this.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormRoomScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 561);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.txtInstructorIDBox);
            this.Controls.Add(this.lblSchedID);
            this.Controls.Add(this.txtIDBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRoomScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Scanner";
            this.Load += new System.EventHandler(this.FormRoomScanner_Load);
            this.Shown += new System.EventHandler(this.FormRoomScanner_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Timer TimerSubject;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.TextBox txtInstructorIDBox;
        private System.Windows.Forms.Label lblSchedID;
        private System.Windows.Forms.Button btnSelectRoom;
        private System.Windows.Forms.Label lblRoom;
    }
}

