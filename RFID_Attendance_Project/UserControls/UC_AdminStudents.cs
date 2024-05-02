using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_AdminStudents : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_AdminStudents()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void UC_AdminStudents_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        DataTable dt = new DataTable();

        private async Task LoadStudents()
        {
            try
            {
                string loadStudentsQuery = "SELECT student_id, firstname, middlename, lastname, section_year, card_id, contact, parent_contact, picture FROM tbl_students;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(loadStudentsQuery, conn))
                    {
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                            dgvStudentList.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async void dgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowGraphs();
                ShowInfo();
            }
        }

        private void ShowInfo()
        {
            string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();
            string selected_lastname = dgvStudentList.CurrentRow.Cells["lastname"].Value.ToString();
            string selected_firstname = dgvStudentList.CurrentRow.Cells["firstName"].Value.ToString();
            string selected_middlename = dgvStudentList.CurrentRow.Cells["middleName"].Value.ToString();
            string selected_secyear = dgvStudentList.CurrentRow.Cells["section_year"].Value.ToString();
            string selected_rfid = dgvStudentList.CurrentRow.Cells["card_id"].Value.ToString();
            string selected_contact = dgvStudentList.CurrentRow.Cells["contact"].Value.ToString();
            string selected_parentcontact = dgvStudentList.CurrentRow.Cells["parent_contact"].Value.ToString();

            DataGridViewImageCell imageCell = dgvStudentList.CurrentRow.Cells["picture"] as DataGridViewImageCell;

            if (imageCell.Value != null && imageCell.Value is byte[])
            {
                byte[] imageData = (byte[])imageCell.Value;

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image selected_image = Image.FromStream(ms);
                    picStudent.Image = selected_image;
                }
            }

            txtStudentId.Text = selected_studentid;
            txtFirstName.Text = selected_firstname;
            txtLastName.Text = selected_lastname;
            txtMiddleName.Text = selected_middlename;
            txtSecYear.Text = selected_secyear;
            txtRFID.Text = selected_rfid;
            txtContact.Text = selected_contact;
            txtParentContact.Text = selected_parentcontact;
        }

        private async Task ShowGraphs()
        {
            string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // STUDENT PERCENTAGE
                    string classAttendanceQuery = "SELECT Total_Attendance, Total_Classes_Section FROM view_total_student_attendance " +
                                                  "JOIN view_total_section_attendance on view_total_student_attendance.Section = view_total_section_attendance.Section " +
                                                  "WHERE User_ID = @UserID;";
                    using (MySqlCommand command = new MySqlCommand(classAttendanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", selected_studentid);

                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            chartStudentPercentage.Series.Clear();
                            while (await reader.ReadAsync())
                            {
                                int totalStudentAttendance = Convert.ToInt32(reader["Total_Attendance"]);
                                int totalClassesConducted = Convert.ToInt32(reader["Total_Classes_Section"]);
                                double studentPercentage = ((double)totalStudentAttendance / totalClassesConducted) * 100;

                                Series series_totalstudents = chartStudentPercentage.Series.Add("StudentPercentage");
                                series_totalstudents.ChartType = SeriesChartType.Doughnut;
                                series_totalstudents.Points.Clear();
                                series_totalstudents.Points.AddY(100 - studentPercentage);
                                series_totalstudents.Points.AddY(studentPercentage);
                                series_totalstudents.Points[0].Label = "Absents: #VALY{0.00}%";
                                series_totalstudents.Points[0].Font = new Font("Arial", 12f);
                                series_totalstudents.Points[1].Label = "Presents: #VALY{0.00}%";
                                series_totalstudents.Points[1].Font = new Font("Arial", 14f);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                chartStudentPercentage.Series.Clear();
            }
        }

        private void btnViewStudentDetails_Click(object sender, EventArgs e)
        {
            PopAdminStudentDetails dialog = new PopAdminStudentDetails();
            dialog.ShowDialog();
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            PopAdminStudentSummary dialog = new PopAdminStudentSummary();
            dialog.ShowDialog();
        }

        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("firstname LIKE '%{0}%' OR middlename LIKE '%{0}%' OR lastname LIKE '%{0}%'  OR student_id LIKE '%{0}%' OR setion_year LIKE '%{0}%'", txtSearchStudent.Text);
        }
    }
}
