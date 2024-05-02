namespace RFID_Attendance_Project.UserControls
{
    partial class UC_UserStudents
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
            this.txtSearchStudent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStudentList = new System.Windows.Forms.DataGridView();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.section_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.chartStudentPercentage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chartAttendancePerClass = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtParentContact = new System.Windows.Forms.TextBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtSecYear = new System.Windows.Forms.TextBox();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnViewStudentDetails = new System.Windows.Forms.Button();
            this.btnViewSummary = new System.Windows.Forms.Button();
            this.btnUploadPic = new System.Windows.Forms.Button();
            this.btnChangePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAttendancePerClass)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchStudent
            // 
            this.txtSearchStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchStudent.Location = new System.Drawing.Point(135, 49);
            this.txtSearchStudent.Name = "txtSearchStudent";
            this.txtSearchStudent.Size = new System.Drawing.Size(169, 20);
            this.txtSearchStudent.TabIndex = 24;
            this.txtSearchStudent.TextChanged += new System.EventHandler(this.txtSearchStudent_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(30, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Search Student:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(118, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Students";
            // 
            // dgvStudentList
            // 
            this.dgvStudentList.AllowUserToAddRows = false;
            this.dgvStudentList.AllowUserToDeleteRows = false;
            this.dgvStudentList.AllowUserToResizeRows = false;
            this.dgvStudentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudentList.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.lastname,
            this.firstname,
            this.middlename,
            this.section_year,
            this.card_id,
            this.contact,
            this.parent_contact,
            this.picture});
            this.dgvStudentList.Location = new System.Drawing.Point(33, 75);
            this.dgvStudentList.MultiSelect = false;
            this.dgvStudentList.Name = "dgvStudentList";
            this.dgvStudentList.ReadOnly = true;
            this.dgvStudentList.RowHeadersVisible = false;
            this.dgvStudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentList.Size = new System.Drawing.Size(271, 327);
            this.dgvStudentList.TabIndex = 100;
            this.dgvStudentList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentList_CellClick);
            // 
            // student_id
            // 
            this.student_id.DataPropertyName = "student_id";
            this.student_id.HeaderText = "Student ID";
            this.student_id.Name = "student_id";
            this.student_id.ReadOnly = true;
            this.student_id.Width = 85;
            // 
            // lastname
            // 
            this.lastname.DataPropertyName = "lastname";
            this.lastname.HeaderText = "Last Name";
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            // 
            // firstname
            // 
            this.firstname.DataPropertyName = "firstname";
            this.firstname.HeaderText = "First Name";
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            this.firstname.Width = 125;
            // 
            // middlename
            // 
            this.middlename.DataPropertyName = "middlename";
            this.middlename.HeaderText = "Middle Name";
            this.middlename.Name = "middlename";
            this.middlename.ReadOnly = true;
            // 
            // section_year
            // 
            this.section_year.DataPropertyName = "section_year";
            this.section_year.HeaderText = "section_year";
            this.section_year.Name = "section_year";
            this.section_year.ReadOnly = true;
            this.section_year.Visible = false;
            this.section_year.Width = 92;
            // 
            // card_id
            // 
            this.card_id.DataPropertyName = "card_id";
            this.card_id.HeaderText = "card_id";
            this.card_id.Name = "card_id";
            this.card_id.ReadOnly = true;
            this.card_id.Visible = false;
            this.card_id.Width = 67;
            // 
            // contact
            // 
            this.contact.DataPropertyName = "contact";
            this.contact.HeaderText = "contact";
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            this.contact.Visible = false;
            this.contact.Width = 68;
            // 
            // parent_contact
            // 
            this.parent_contact.DataPropertyName = "parent_contact";
            this.parent_contact.HeaderText = "parent_contact";
            this.parent_contact.Name = "parent_contact";
            this.parent_contact.ReadOnly = true;
            this.parent_contact.Visible = false;
            this.parent_contact.Width = 104;
            // 
            // picture
            // 
            this.picture.DataPropertyName = "picture";
            this.picture.HeaderText = "picture";
            this.picture.Name = "picture";
            this.picture.ReadOnly = true;
            this.picture.Visible = false;
            this.picture.Width = 45;
            // 
            // chartStudentPercentage
            // 
            this.chartStudentPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartStudentPercentage.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartStudentPercentage.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartStudentPercentage.ChartAreas.Add(chartArea1);
            this.chartStudentPercentage.Location = new System.Drawing.Point(887, 49);
            this.chartStudentPercentage.Name = "chartStudentPercentage";
            this.chartStudentPercentage.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Name = "Series1";
            this.chartStudentPercentage.Series.Add(series1);
            this.chartStudentPercentage.Size = new System.Drawing.Size(300, 300);
            this.chartStudentPercentage.TabIndex = 27;
            this.chartStudentPercentage.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Student Attendance Percentage";
            this.chartStudentPercentage.Titles.Add(title1);
            // 
            // picStudent
            // 
            this.picStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picStudent.BackColor = System.Drawing.Color.White;
            this.picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudent.Location = new System.Drawing.Point(346, 49);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(150, 150);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudent.TabIndex = 25;
            this.picStudent.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(704, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "Student Info";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(693, 287);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(182, 30);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.SlateBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(693, 287);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(182, 30);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update Student";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chartAttendancePerClass
            // 
            this.chartAttendancePerClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartAttendancePerClass.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartAttendancePerClass.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartAttendancePerClass.ChartAreas.Add(chartArea2);
            this.chartAttendancePerClass.Location = new System.Drawing.Point(346, 355);
            this.chartAttendancePerClass.Name = "chartAttendancePerClass";
            this.chartAttendancePerClass.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartAttendancePerClass.Series.Add(series2);
            this.chartAttendancePerClass.Size = new System.Drawing.Size(841, 119);
            this.chartAttendancePerClass.TabIndex = 35;
            this.chartAttendancePerClass.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Student Attendance Percentage per Class";
            this.chartAttendancePerClass.Titles.Add(title2);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.BlueViolet;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(508, 287);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(182, 30);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete Student";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtParentContact
            // 
            this.txtParentContact.Location = new System.Drawing.Point(187, 207);
            this.txtParentContact.Name = "txtParentContact";
            this.txtParentContact.Size = new System.Drawing.Size(176, 20);
            this.txtParentContact.TabIndex = 17;
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(187, 4);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(176, 20);
            this.txtStudentId.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(20, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Parent/Guardian Email:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(116, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Contact:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(98, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "RFID Card:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(18, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Section and Year Level:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(100, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "LastName:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(84, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Midde Name:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(95, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "First Name:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(100, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Student ID:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(187, 62);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 20);
            this.txtFirstName.TabIndex = 12;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(187, 91);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(176, 20);
            this.txtMiddleName.TabIndex = 13;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(187, 120);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(176, 20);
            this.txtLastName.TabIndex = 14;
            // 
            // txtSecYear
            // 
            this.txtSecYear.Enabled = false;
            this.txtSecYear.Location = new System.Drawing.Point(187, 149);
            this.txtSecYear.Name = "txtSecYear";
            this.txtSecYear.Size = new System.Drawing.Size(176, 20);
            this.txtSecYear.TabIndex = 15;
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(187, 33);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(176, 20);
            this.txtRFID.TabIndex = 11;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(187, 178);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(176, 20);
            this.txtContact.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtContact, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtRFID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtStudentId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtParentContact, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSecYear, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtLastName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtMiddleName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtFirstName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(508, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50006F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50255F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49711F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 234);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(508, 319);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(367, 30);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnViewStudentDetails
            // 
            this.btnViewStudentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewStudentDetails.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewStudentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStudentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStudentDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewStudentDetails.Location = new System.Drawing.Point(33, 408);
            this.btnViewStudentDetails.Name = "btnViewStudentDetails";
            this.btnViewStudentDetails.Size = new System.Drawing.Size(271, 30);
            this.btnViewStudentDetails.TabIndex = 102;
            this.btnViewStudentDetails.Text = "View Students Details";
            this.btnViewStudentDetails.UseVisualStyleBackColor = false;
            this.btnViewStudentDetails.Click += new System.EventHandler(this.btnViewStudentDetails_Click);
            // 
            // btnViewSummary
            // 
            this.btnViewSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSummary.BackColor = System.Drawing.Color.SlateBlue;
            this.btnViewSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSummary.ForeColor = System.Drawing.Color.White;
            this.btnViewSummary.Location = new System.Drawing.Point(33, 444);
            this.btnViewSummary.Name = "btnViewSummary";
            this.btnViewSummary.Size = new System.Drawing.Size(271, 30);
            this.btnViewSummary.TabIndex = 101;
            this.btnViewSummary.Text = "View Summary";
            this.btnViewSummary.UseVisualStyleBackColor = false;
            this.btnViewSummary.Click += new System.EventHandler(this.btnViewSummary_Click);
            // 
            // btnUploadPic
            // 
            this.btnUploadPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUploadPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPic.ForeColor = System.Drawing.Color.White;
            this.btnUploadPic.Location = new System.Drawing.Point(346, 205);
            this.btnUploadPic.Name = "btnUploadPic";
            this.btnUploadPic.Size = new System.Drawing.Size(150, 30);
            this.btnUploadPic.TabIndex = 33;
            this.btnUploadPic.Text = "Upload Picture";
            this.btnUploadPic.UseVisualStyleBackColor = false;
            this.btnUploadPic.Click += new System.EventHandler(this.btnUploadPic_Click);
            // 
            // btnChangePic
            // 
            this.btnChangePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePic.BackColor = System.Drawing.Color.SlateBlue;
            this.btnChangePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePic.ForeColor = System.Drawing.Color.White;
            this.btnChangePic.Location = new System.Drawing.Point(346, 205);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(150, 30);
            this.btnChangePic.TabIndex = 18;
            this.btnChangePic.Text = "Change Picture";
            this.btnChangePic.UseVisualStyleBackColor = false;
            this.btnChangePic.Visible = false;
            this.btnChangePic.Click += new System.EventHandler(this.btnChangePic_Click);
            // 
            // UC_UserStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnViewStudentDetails);
            this.Controls.Add(this.btnViewSummary);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.chartAttendancePerClass);
            this.Controls.Add(this.btnChangePic);
            this.Controls.Add(this.btnUploadPic);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chartStudentPercentage);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.picStudent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStudentList);
            this.Controls.Add(this.btnUpdate);
            this.Name = "UC_UserStudents";
            this.Size = new System.Drawing.Size(1234, 491);
            this.Load += new System.EventHandler(this.UC_UserStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAttendancePerClass)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStudentList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudentPercentage;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAttendancePerClass;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtParentContact;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtSecYear;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn middlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn section_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent_contact;
        private System.Windows.Forms.DataGridViewImageColumn picture;
        private System.Windows.Forms.Button btnViewStudentDetails;
        private System.Windows.Forms.Button btnViewSummary;
        private System.Windows.Forms.Button btnUploadPic;
        private System.Windows.Forms.Button btnChangePic;
    }
}
