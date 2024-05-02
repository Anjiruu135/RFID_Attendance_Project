namespace RFID_Attendance_Project.UserControls
{
    partial class UC_AdminRecords
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picTimeOut = new System.Windows.Forms.PictureBox();
            this.picTimeIn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartAttendanceHistory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAttendanceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(275, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 29);
            this.label1.TabIndex = 64;
            this.label1.Text = "Scanner Record";
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.AllowUserToResizeColumns = false;
            this.dgvRecords.AllowUserToResizeRows = false;
            this.dgvRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.user_id,
            this.fullname,
            this.date,
            this.time_in,
            this.time_out});
            this.dgvRecords.Location = new System.Drawing.Point(53, 72);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowHeadersVisible = false;
            this.dgvRecords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(662, 390);
            this.dgvRecords.TabIndex = 63;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // user_id
            // 
            this.user_id.DataPropertyName = "user_id";
            this.user_id.HeaderText = "User ID";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            this.user_id.Width = 200;
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            this.fullname.HeaderText = "Fullname";
            this.fullname.Name = "fullname";
            this.fullname.ReadOnly = true;
            this.fullname.Width = 200;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Visible = false;
            // 
            // time_in
            // 
            this.time_in.DataPropertyName = "time_in";
            this.time_in.HeaderText = "Time In";
            this.time_in.Name = "time_in";
            this.time_in.ReadOnly = true;
            this.time_in.Width = 130;
            // 
            // time_out
            // 
            this.time_out.DataPropertyName = "time_out";
            this.time_out.HeaderText = "Time Out";
            this.time_out.Name = "time_out";
            this.time_out.ReadOnly = true;
            this.time_out.Width = 130;
            // 
            // picTimeOut
            // 
            this.picTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picTimeOut.BackColor = System.Drawing.Color.White;
            this.picTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTimeOut.Location = new System.Drawing.Point(951, 46);
            this.picTimeOut.Name = "picTimeOut";
            this.picTimeOut.Size = new System.Drawing.Size(208, 198);
            this.picTimeOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTimeOut.TabIndex = 73;
            this.picTimeOut.TabStop = false;
            // 
            // picTimeIn
            // 
            this.picTimeIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picTimeIn.BackColor = System.Drawing.Color.White;
            this.picTimeIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTimeIn.Location = new System.Drawing.Point(737, 46);
            this.picTimeIn.Name = "picTimeIn";
            this.picTimeIn.Size = new System.Drawing.Size(208, 198);
            this.picTimeIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTimeIn.TabIndex = 74;
            this.picTimeIn.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(431, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Select Date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker.CustomFormat = "dd MMMM yyyy";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(515, 46);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 75;
            this.dateTimePicker.Value = new System.DateTime(2024, 3, 27, 0, 0, 0, 0);
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(733, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 76;
            this.label3.Text = "Recent Time In";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(947, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 77;
            this.label4.Text = "Recent Time Out";
            // 
            // chartAttendanceHistory
            // 
            this.chartAttendanceHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chartAttendanceHistory.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartAttendanceHistory.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Students";
            chartArea1.Name = "ChartArea1";
            this.chartAttendanceHistory.ChartAreas.Add(chartArea1);
            this.chartAttendanceHistory.Location = new System.Drawing.Point(737, 276);
            this.chartAttendanceHistory.Name = "chartAttendanceHistory";
            this.chartAttendanceHistory.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series1";
            this.chartAttendanceHistory.Series.Add(series1);
            this.chartAttendanceHistory.Size = new System.Drawing.Size(422, 186);
            this.chartAttendanceHistory.TabIndex = 78;
            this.chartAttendanceHistory.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Record History";
            this.chartAttendanceHistory.Titles.Add(title1);
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTimeIn.Location = new System.Drawing.Point(734, 247);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(211, 13);
            this.lblTimeIn.TabIndex = 79;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTimeOut.Location = new System.Drawing.Point(948, 247);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(211, 13);
            this.lblTimeOut.TabIndex = 80;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(53, 33);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 35);
            this.btnExport.TabIndex = 81;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UC_AdminRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.chartAttendanceHistory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.picTimeIn);
            this.Controls.Add(this.picTimeOut);
            this.Name = "UC_AdminRecords";
            this.Size = new System.Drawing.Size(1234, 491);
            this.Load += new System.EventHandler(this.UC_AdminRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAttendanceHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.PictureBox picTimeOut;
        private System.Windows.Forms.PictureBox picTimeIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAttendanceHistory;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_out;
    }
}
