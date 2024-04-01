namespace RFID_Attendance_Project.UserControls
{
    partial class UC_UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_UserDashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblAdvisory = new System.Windows.Forms.Label();
            this.lblNoStudents = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.schedule_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.chartTotalStudents = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picEvents = new System.Windows.Forms.PictureBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chartAdvisoryPercentage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStudentMostAbsent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerCarousel = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAdvisoryPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentMostAbsent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Location = new System.Drawing.Point(7, 455);
            this.lblTime.MinimumSize = new System.Drawing.Size(160, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(160, 13);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.Location = new System.Drawing.Point(8, 470);
            this.lblDate.MinimumSize = new System.Drawing.Size(160, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(160, 13);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.lblTime);
            this.groupBox3.Controls.Add(this.lblDate);
            this.groupBox3.Controls.Add(this.lblAdvisory);
            this.groupBox3.Controls.Add(this.lblNoStudents);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(1059, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 491);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // lblAdvisory
            // 
            this.lblAdvisory.AutoSize = true;
            this.lblAdvisory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvisory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAdvisory.Location = new System.Drawing.Point(12, 166);
            this.lblAdvisory.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblAdvisory.Name = "lblAdvisory";
            this.lblAdvisory.Size = new System.Drawing.Size(150, 20);
            this.lblAdvisory.TabIndex = 14;
            this.lblAdvisory.Text = "Advisory";
            this.lblAdvisory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNoStudents
            // 
            this.lblNoStudents.AutoSize = true;
            this.lblNoStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNoStudents.Location = new System.Drawing.Point(81, 238);
            this.lblNoStudents.Name = "lblNoStudents";
            this.lblNoStudents.Size = new System.Drawing.Size(19, 20);
            this.lblNoStudents.TabIndex = 12;
            this.lblNoStudents.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(4, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your Students\r\nin Campus: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.AllowUserToAddRows = false;
            this.dgvSchedules.AllowUserToDeleteRows = false;
            this.dgvSchedules.AllowUserToResizeColumns = false;
            this.dgvSchedules.AllowUserToResizeRows = false;
            this.dgvSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvSchedules.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.schedule_id});
            this.dgvSchedules.Location = new System.Drawing.Point(787, 35);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.ReadOnly = true;
            this.dgvSchedules.RowHeadersVisible = false;
            this.dgvSchedules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSchedules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedules.Size = new System.Drawing.Size(255, 433);
            this.dgvSchedules.TabIndex = 12;
            // 
            // schedule_id
            // 
            this.schedule_id.DataPropertyName = "schedule_id";
            this.schedule_id.HeaderText = "Schedules";
            this.schedule_id.Name = "schedule_id";
            this.schedule_id.ReadOnly = true;
            this.schedule_id.Width = 275;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(783, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 20);
            this.label18.TabIndex = 57;
            this.label18.Text = "Schedules Today:";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lblTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.Location = new System.Drawing.Point(414, 344);
            this.lblTotalStudents.MinimumSize = new System.Drawing.Size(160, 20);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(160, 29);
            this.lblTotalStudents.TabIndex = 62;
            this.lblTotalStudents.Text = "00 Students";
            this.lblTotalStudents.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTotalStudents.Visible = false;
            // 
            // chartTotalStudents
            // 
            this.chartTotalStudents.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chartTotalStudents.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartTotalStudents.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.chartTotalStudents.ChartAreas.Add(chartArea4);
            this.chartTotalStudents.Location = new System.Drawing.Point(402, 234);
            this.chartTotalStudents.Name = "chartTotalStudents";
            this.chartTotalStudents.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Color = System.Drawing.Color.White;
            series3.Name = "Series1";
            this.chartTotalStudents.Series.Add(series3);
            this.chartTotalStudents.Size = new System.Drawing.Size(185, 234);
            this.chartTotalStudents.TabIndex = 63;
            this.chartTotalStudents.Text = "chart2";
            title4.Name = "Title1";
            title4.Text = "No. of Students in your Advisory";
            this.chartTotalStudents.Titles.Add(title4);
            // 
            // picEvents
            // 
            this.picEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picEvents.BackColor = System.Drawing.Color.White;
            this.picEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEvents.Location = new System.Drawing.Point(20, 35);
            this.picEvents.Name = "picEvents";
            this.picEvents.Size = new System.Drawing.Size(761, 193);
            this.picEvents.TabIndex = 68;
            this.picEvents.TabStop = false;
            // 
            // lblPercentage
            // 
            this.lblPercentage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.BackColor = System.Drawing.Color.White;
            this.lblPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.Location = new System.Drawing.Point(601, 330);
            this.lblPercentage.MinimumSize = new System.Drawing.Size(175, 20);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(175, 42);
            this.lblPercentage.TabIndex = 69;
            this.lblPercentage.Text = "000.00%";
            this.lblPercentage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPercentage.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(16, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 71;
            this.label5.Text = "Announcements:";
            // 
            // chartAdvisoryPercentage
            // 
            this.chartAdvisoryPercentage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chartAdvisoryPercentage.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartAdvisoryPercentage.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.Name = "ChartArea1";
            this.chartAdvisoryPercentage.ChartAreas.Add(chartArea5);
            this.chartAdvisoryPercentage.Location = new System.Drawing.Point(596, 234);
            this.chartAdvisoryPercentage.Name = "chartAdvisoryPercentage";
            this.chartAdvisoryPercentage.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartAdvisoryPercentage.Size = new System.Drawing.Size(185, 234);
            this.chartAdvisoryPercentage.TabIndex = 70;
            this.chartAdvisoryPercentage.Text = "chart2";
            title5.Name = "Title1";
            title5.Text = "Advisory Attendance Percentage";
            this.chartAdvisoryPercentage.Titles.Add(title5);
            // 
            // chartStudentMostAbsent
            // 
            this.chartStudentMostAbsent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chartStudentMostAbsent.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartStudentMostAbsent.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea6.Name = "ChartArea1";
            this.chartStudentMostAbsent.ChartAreas.Add(chartArea6);
            this.chartStudentMostAbsent.Location = new System.Drawing.Point(20, 234);
            this.chartStudentMostAbsent.Name = "chartStudentMostAbsent";
            this.chartStudentMostAbsent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.MarkerColor = System.Drawing.Color.Blue;
            series4.Name = "Series1";
            this.chartStudentMostAbsent.Series.Add(series4);
            this.chartStudentMostAbsent.Size = new System.Drawing.Size(376, 234);
            this.chartStudentMostAbsent.TabIndex = 72;
            this.chartStudentMostAbsent.Text = "chart2";
            title6.Name = "Title1";
            title6.Text = "Students with Highest Percentage of Absents";
            this.chartStudentMostAbsent.Titles.Add(title6);
            // 
            // UC_UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.chartStudentMostAbsent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chartAdvisoryPercentage);
            this.Controls.Add(this.picEvents);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.chartTotalStudents);
            this.Controls.Add(this.dgvSchedules);
            this.Controls.Add(this.groupBox3);
            this.Name = "UC_UserDashboard";
            this.Size = new System.Drawing.Size(1234, 491);
            this.Load += new System.EventHandler(this.UC_UserDashboard_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAdvisoryPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentMostAbsent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNoStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAdvisory;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule_id;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalStudents;
        private System.Windows.Forms.PictureBox picEvents;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAdvisoryPercentage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudentMostAbsent;
        private System.Windows.Forms.Timer timerCarousel;
    }
}
