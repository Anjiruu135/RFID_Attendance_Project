using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using RFID_Attendance_Project.Modules;
using RFID_Attendance_Project.UserControls;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project
{
    public partial class PopAttendanceDetails : Form
    {
        string connectionString = Database.connectionString;

        public PopAttendanceDetails()
        {
            InitializeComponent();
            lblClass.Text = selectedClass;
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

        int enrolledStudents = UC_UserAttendance.PublicTotalStudents;
        int totaldays = UC_UserAttendance.PublicTotalDays;
        string selectedClass = UC_UserAttendance.PublicSelectedClass;
        string classSection = UC_UserAttendance.PublicClassSection;

        private async Task ShowDetailsBySchedule()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string ClassAttendanceQuery = $@"
                        SELECT tbl_classattendance.schedule_id as Schedule, DATE_FORMAT(STR_TO_DATE(date, '%W, %M %e, %Y'), '%Y-%m-%d') AS Date, COUNT(DISTINCT fullname) AS Attendance
                        FROM tbl_classattendance 
                        JOIN view_attendance_users ON tbl_classattendance.user_id = view_attendance_users.user_id 
                        WHERE user_type = 'student' AND schedule_id LIKE '{selectedClass}%'
                        GROUP BY Schedule, Date
                        ORDER BY Date ASC;
                    ";

                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable AttendanceTable = new DataTable();
                            AttendanceTable.Load(reader);

                            AttendanceTable.Columns.Add("Attendance_Percentage", typeof(double));

                            foreach (DataRow row in AttendanceTable.Rows)
                            {
                                int studentsPresent = Convert.ToInt32(row["Attendance"]);
                                double percentage = (double)studentsPresent / enrolledStudents * 100.0;
                                row["Attendance_Percentage"] = Math.Round(percentage, 2);
                            }

                            dgvDetailsResult.DataSource = AttendanceTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ShowDetailsByStudent()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string ClassAttendanceQuery = $@"
                        SELECT CONCAT(view_attendance_users.lastname, ', ', view_attendance_users.firstname) as Fullname, 
                        COALESCE(COUNT(DISTINCT tbl_classattendance.schedule_id), 0) AS Total_Attendance 
                        FROM view_attendance_users 
                        LEFT JOIN tbl_classattendance ON tbl_classattendance.user_id = view_attendance_users.user_id 
                        AND tbl_classattendance.schedule_id LIKE '{selectedClass}%' 
                        WHERE view_attendance_users.user_type = 'student' AND view_attendance_users.section = '{classSection}'
                        GROUP BY view_attendance_users.user_id 
                        ORDER BY Fullname ASC 
                    ";

                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable AttendanceTable = new DataTable();
                            AttendanceTable.Load(reader);

                            AttendanceTable.Columns.Add("Attendance_Percentage", typeof(double));

                            foreach (DataRow row in AttendanceTable.Rows)
                            {
                                int attendance = Convert.ToInt32(row["Total_Attendance"]);
                                double percentage = (double)attendance / totaldays * 100.0;
                                row["Attendance_Percentage"] = Math.Round(percentage, 2);
                            }

                            dgvDetailsResult.DataSource = AttendanceTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ShowDetailsByDate()
        {
            try
            {
                string selectedDate = PopDateSelect.PublicSelectedDate;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    await connection.OpenAsync();
                    string ClassAttendanceQuery = $@"
                        SELECT tbl_classattendance.schedule_id as Schedule, tbl_classattendance.fullname as Fullname, DATE_FORMAT(STR_TO_DATE(date, '%W, %M %e, %Y'), '%Y-%m-%d') AS Schedule_Date
                        FROM tbl_classattendance 
                        LEFT JOIN view_attendance_users ON tbl_classattendance.user_id = view_attendance_users.user_id 
                        AND tbl_classattendance.schedule_id LIKE '{selectedClass}%' 
                        WHERE view_attendance_users.user_type = 'student' AND view_attendance_users.section = '{classSection}' AND DATE_FORMAT(STR_TO_DATE(date, '%W, %M %e, %Y'), '%Y-%m-%d') = '{selectedDate}'
                        GROUP BY Schedule, Date, Fullname  
						ORDER BY tbl_classattendance.Date ASC;
                    ";
                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable AttendanceTable = new DataTable();
                            AttendanceTable.Load(reader);
                            dgvDetailsResult.DataSource = AttendanceTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.Text == "by Schedule")
            {
                await ShowDetailsBySchedule();
            }
            else if (cmbCategory.Text == "by Student")
            {
                await ShowDetailsByStudent();
            }
            else if (cmbCategory.Text == "by Date")
            {
                PopDateSelect dialog = new PopDateSelect();
                dialog.ShowDialog();
                await ShowDetailsByDate();
            }
            else
            {
                dgvDetailsResult.DataSource = null;
            }
        }

        private void cmbCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            dgvDetailsResult.DataSource = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog openFileDialog = new SaveFileDialog();
                openFileDialog.InitialDirectory = "C:\\Users\\TEDD\\Documents";
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|Excel 2007 (*.xls)|*.xls";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = Excel.DataGridView_To_Datatable(dgvDetailsResult);
                    dt.exportToExcel(openFileDialog.FileName);
                    MessageBox.Show("Table exported successfully", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
