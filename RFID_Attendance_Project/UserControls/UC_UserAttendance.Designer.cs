namespace RFID_Attendance_Project.UserControls
{
    partial class UC_UserAttendance
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label4 = new System.Windows.Forms.Label();
            this.chartStudentsPerClass = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClassList = new System.Windows.Forms.DataGridView();
            this.class_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartMostAbsents = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnViewAttendanceDetails = new System.Windows.Forms.Button();
            this.chartAveragePercent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHighestPercent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTotalClasses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalClasses = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.chartTotalStudents = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnViewSummary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentsPerClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMostAbsents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAveragePercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHighestPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(617, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "Class Attendance Stats";
            // 
            // chartStudentsPerClass
            // 
            this.chartStudentsPerClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartStudentsPerClass.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartStudentsPerClass.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartStudentsPerClass.ChartAreas.Add(chartArea1);
            this.chartStudentsPerClass.Location = new System.Drawing.Point(351, 46);
            this.chartStudentsPerClass.Name = "chartStudentsPerClass";
            this.chartStudentsPerClass.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.MarkerColor = System.Drawing.Color.DarkBlue;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series1";
            this.chartStudentsPerClass.Series.Add(series1);
            this.chartStudentsPerClass.Size = new System.Drawing.Size(375, 176);
            this.chartStudentsPerClass.TabIndex = 34;
            this.chartStudentsPerClass.Text = "chart2";
            title1.Name = "Title1";
            title1.Text = "Students per Class Session";
            this.chartStudentsPerClass.Titles.Add(title1);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(141, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(50, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Search Class:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(143, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Classes";
            // 
            // dgvClassList
            // 
            this.dgvClassList.AllowUserToAddRows = false;
            this.dgvClassList.AllowUserToDeleteRows = false;
            this.dgvClassList.AllowUserToResizeColumns = false;
            this.dgvClassList.AllowUserToResizeRows = false;
            this.dgvClassList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.class_name});
            this.dgvClassList.Location = new System.Drawing.Point(53, 72);
            this.dgvClassList.Name = "dgvClassList";
            this.dgvClassList.ReadOnly = true;
            this.dgvClassList.RowHeadersVisible = false;
            this.dgvClassList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvClassList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassList.Size = new System.Drawing.Size(271, 354);
            this.dgvClassList.TabIndex = 28;
            this.dgvClassList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassList_CellClick);
            // 
            // class_name
            // 
            this.class_name.DataPropertyName = "class_name";
            this.class_name.HeaderText = "Class ID";
            this.class_name.Name = "class_name";
            this.class_name.ReadOnly = true;
            this.class_name.Width = 750;
            // 
            // chartMostAbsents
            // 
            this.chartMostAbsents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartMostAbsents.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartMostAbsents.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartMostAbsents.ChartAreas.Add(chartArea2);
            this.chartMostAbsents.Location = new System.Drawing.Point(748, 250);
            this.chartMostAbsents.Name = "chartMostAbsents";
            this.chartMostAbsents.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.MarkerColor = System.Drawing.Color.Blue;
            series2.Name = "Series1";
            this.chartMostAbsents.Series.Add(series2);
            this.chartMostAbsents.Size = new System.Drawing.Size(422, 176);
            this.chartMostAbsents.TabIndex = 51;
            this.chartMostAbsents.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Students with Most Absents";
            this.chartMostAbsents.Titles.Add(title2);
            // 
            // btnViewAttendanceDetails
            // 
            this.btnViewAttendanceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAttendanceDetails.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewAttendanceDetails.Enabled = false;
            this.btnViewAttendanceDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAttendanceDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAttendanceDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewAttendanceDetails.Location = new System.Drawing.Point(748, 432);
            this.btnViewAttendanceDetails.Name = "btnViewAttendanceDetails";
            this.btnViewAttendanceDetails.Size = new System.Drawing.Size(422, 30);
            this.btnViewAttendanceDetails.TabIndex = 52;
            this.btnViewAttendanceDetails.Text = "Class Attendance Details";
            this.btnViewAttendanceDetails.UseVisualStyleBackColor = false;
            this.btnViewAttendanceDetails.Click += new System.EventHandler(this.btnViewAttendanceDetails_Click);
            // 
            // chartAveragePercent
            // 
            this.chartAveragePercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartAveragePercent.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartAveragePercent.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chartAveragePercent.ChartAreas.Add(chartArea3);
            this.chartAveragePercent.Location = new System.Drawing.Point(748, 46);
            this.chartAveragePercent.Name = "chartAveragePercent";
            this.chartAveragePercent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Color = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartAveragePercent.Series.Add(series3);
            this.chartAveragePercent.Size = new System.Drawing.Size(208, 198);
            this.chartAveragePercent.TabIndex = 54;
            this.chartAveragePercent.Text = "chart2";
            title3.Name = "Title1";
            title3.Text = "Average Stats";
            this.chartAveragePercent.Titles.Add(title3);
            // 
            // chartHighestPercent
            // 
            this.chartHighestPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartHighestPercent.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartHighestPercent.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.chartHighestPercent.ChartAreas.Add(chartArea4);
            this.chartHighestPercent.Location = new System.Drawing.Point(962, 46);
            this.chartHighestPercent.Name = "chartHighestPercent";
            this.chartHighestPercent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Color = System.Drawing.Color.White;
            series4.Name = "Series1";
            this.chartHighestPercent.Series.Add(series4);
            this.chartHighestPercent.Size = new System.Drawing.Size(208, 198);
            this.chartHighestPercent.TabIndex = 55;
            this.chartHighestPercent.Text = "chart2";
            title4.Name = "Title1";
            title4.Text = "Highest / Lowest Stats";
            this.chartHighestPercent.Titles.Add(title4);
            // 
            // chartTotalClasses
            // 
            this.chartTotalClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTotalClasses.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartTotalClasses.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.Name = "ChartArea1";
            this.chartTotalClasses.ChartAreas.Add(chartArea5);
            this.chartTotalClasses.Location = new System.Drawing.Point(351, 228);
            this.chartTotalClasses.Name = "chartTotalClasses";
            this.chartTotalClasses.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Color = System.Drawing.Color.White;
            series5.Name = "Series1";
            this.chartTotalClasses.Series.Add(series5);
            this.chartTotalClasses.Size = new System.Drawing.Size(185, 234);
            this.chartTotalClasses.TabIndex = 58;
            this.chartTotalClasses.Text = "chart2";
            title5.Name = "Title1";
            title5.Text = "Total No. of Classes Conducted";
            this.chartTotalClasses.Titles.Add(title5);
            // 
            // lblTotalClasses
            // 
            this.lblTotalClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalClasses.AutoSize = true;
            this.lblTotalClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lblTotalClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClasses.Location = new System.Drawing.Point(367, 342);
            this.lblTotalClasses.MinimumSize = new System.Drawing.Size(150, 20);
            this.lblTotalClasses.Name = "lblTotalClasses";
            this.lblTotalClasses.Size = new System.Drawing.Size(150, 24);
            this.lblTotalClasses.TabIndex = 59;
            this.lblTotalClasses.Text = "Total Classes";
            this.lblTotalClasses.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTotalClasses.Visible = false;
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lblTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.Location = new System.Drawing.Point(561, 342);
            this.lblTotalStudents.MinimumSize = new System.Drawing.Size(150, 20);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(150, 24);
            this.lblTotalStudents.TabIndex = 60;
            this.lblTotalStudents.Text = "Total Students";
            this.lblTotalStudents.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTotalStudents.Visible = false;
            // 
            // chartTotalStudents
            // 
            this.chartTotalStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTotalStudents.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartTotalStudents.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea6.Name = "ChartArea1";
            this.chartTotalStudents.ChartAreas.Add(chartArea6);
            this.chartTotalStudents.Location = new System.Drawing.Point(542, 228);
            this.chartTotalStudents.Name = "chartTotalStudents";
            this.chartTotalStudents.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Color = System.Drawing.Color.White;
            series6.Name = "Series1";
            this.chartTotalStudents.Series.Add(series6);
            this.chartTotalStudents.Size = new System.Drawing.Size(185, 234);
            this.chartTotalStudents.TabIndex = 61;
            this.chartTotalStudents.Text = "chart2";
            title6.Name = "Title1";
            title6.Text = "Total No. of Students";
            this.chartTotalStudents.Titles.Add(title6);
            // 
            // btnViewSummary
            // 
            this.btnViewSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSummary.BackColor = System.Drawing.Color.SlateBlue;
            this.btnViewSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSummary.ForeColor = System.Drawing.Color.White;
            this.btnViewSummary.Location = new System.Drawing.Point(53, 432);
            this.btnViewSummary.Name = "btnViewSummary";
            this.btnViewSummary.Size = new System.Drawing.Size(271, 30);
            this.btnViewSummary.TabIndex = 62;
            this.btnViewSummary.Text = "Classes Summary";
            this.btnViewSummary.UseVisualStyleBackColor = false;
            this.btnViewSummary.Click += new System.EventHandler(this.btnViewSummary_Click);
            // 
            // UC_UserAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnViewSummary);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.lblTotalClasses);
            this.Controls.Add(this.chartTotalClasses);
            this.Controls.Add(this.chartHighestPercent);
            this.Controls.Add(this.chartAveragePercent);
            this.Controls.Add(this.btnViewAttendanceDetails);
            this.Controls.Add(this.chartMostAbsents);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chartStudentsPerClass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClassList);
            this.Controls.Add(this.chartTotalStudents);
            this.Name = "UC_UserAttendance";
            this.Size = new System.Drawing.Size(1234, 491);
            this.Load += new System.EventHandler(this.UC_UserAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentsPerClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMostAbsents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAveragePercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHighestPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudentsPerClass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClassList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMostAbsents;
        private System.Windows.Forms.Button btnViewAttendanceDetails;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAveragePercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_name;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHighestPercent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalClasses;
        private System.Windows.Forms.Label lblTotalClasses;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalStudents;
        private System.Windows.Forms.Button btnViewSummary;
    }
}
