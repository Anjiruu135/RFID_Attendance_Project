namespace RFID_Attendance_Project
{
    partial class FormAdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInstructorName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnInstructors = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnRecords = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.lblInstructorName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 35);
            this.panel1.TabIndex = 1;
            // 
            // lblInstructorName
            // 
            this.lblInstructorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstructorName.AutoSize = true;
            this.lblInstructorName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructorName.ForeColor = System.Drawing.Color.White;
            this.lblInstructorName.Location = new System.Drawing.Point(1139, 7);
            this.lblInstructorName.Name = "lblInstructorName";
            this.lblInstructorName.Size = new System.Drawing.Size(83, 22);
            this.lblInstructorName.TabIndex = 1;
            this.lblInstructorName.Text = "(Admin)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFID Attendance Monitoring Software - Admin Panel";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumPurple;
            this.panel2.Controls.Add(this.btnRecords);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnInstructors);
            this.panel2.Controls.Add(this.btnStudents);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1234, 35);
            this.panel2.TabIndex = 3;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.MediumPurple;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(895, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(211, 35);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnInstructors
            // 
            this.btnInstructors.AutoSize = true;
            this.btnInstructors.BackColor = System.Drawing.Color.MediumPurple;
            this.btnInstructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstructors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructors.ForeColor = System.Drawing.Color.White;
            this.btnInstructors.Location = new System.Drawing.Point(448, 0);
            this.btnInstructors.Name = "btnInstructors";
            this.btnInstructors.Size = new System.Drawing.Size(225, 35);
            this.btnInstructors.TabIndex = 3;
            this.btnInstructors.Text = "Instructors";
            this.btnInstructors.UseVisualStyleBackColor = false;
            this.btnInstructors.Click += new System.EventHandler(this.btnInstructors_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.AutoSize = true;
            this.btnStudents.BackColor = System.Drawing.Color.MediumPurple;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(224, 0);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(225, 35);
            this.btnStudents.TabIndex = 2;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.AutoSize = true;
            this.btnDashboard.BackColor = System.Drawing.Color.MediumPurple;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(225, 35);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.Color.SlateBlue;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1105, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 35);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 70);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1234, 491);
            this.panelContainer.TabIndex = 4;
            // 
            // btnRecords
            // 
            this.btnRecords.AutoSize = true;
            this.btnRecords.BackColor = System.Drawing.Color.MediumPurple;
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecords.ForeColor = System.Drawing.Color.White;
            this.btnRecords.Location = new System.Drawing.Point(672, 0);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(225, 35);
            this.btnRecords.TabIndex = 8;
            this.btnRecords.Text = "Records";
            this.btnRecords.UseVisualStyleBackColor = false;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // FormAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 561);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdminMain_FormClosed);
            this.Load += new System.EventHandler(this.FormAdminMain_Load);
            this.Shown += new System.EventHandler(this.FormAdminMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInstructorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnInstructors;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRecords;
    }
}