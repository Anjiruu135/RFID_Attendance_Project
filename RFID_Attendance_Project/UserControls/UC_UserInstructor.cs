using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Attendance_Project.Modules;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.Common;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_UserInstructor : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_UserInstructor()
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

        private async void UC_UserInstructor_Load(object sender, EventArgs e)
        {
            await LoadInstructor();
            await LoadSchedules();
            await ShowInstructorStatsGraphAttendance();
            await ShowInstructorStatsGraphHours();
        }

        private async Task LoadInstructor()
        {
            try
            {
                string loadstudents_query = "SELECT * FROM tbl_users JOIN tbl_instructors ON tbl_users.user_id = tbl_instructors.instructor_id WHERE name = '" + FormLogin.username_display + "'";
                DataTable dt = new DataTable();

                await Task.Run(() =>
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(loadstudents_query, conn))
                        {
                            da.Fill(dt);
                        }
                    }
                });

                foreach (DataRow row in dt.Rows)
                {
                    string instructor_id = row["instructor_id"].ToString();
                    string firstname = row["firstname"].ToString();
                    string middlename = row["middlename"].ToString();
                    string lastname = row["lastname"].ToString();
                    string advisory = row["advisory"].ToString();
                    string department = row["department"].ToString();
                    string card_id = row["card_id"].ToString();
                    string contact = row["contact"].ToString();

                    lblInstructorId.Text = instructor_id;
                    lblFirstName.Text = firstname;
                    lblMiddleName.Text = middlename;
                    lblLastName.Text = lastname;
                    lblAdvisory.Text = advisory;
                    lblDepartment.Text = department;
                    lblRFID.Text = card_id;
                    lblContact.Text = contact;
                }

                string select_pic = "SELECT picture FROM tbl_users JOIN tbl_instructors ON tbl_users.user_id = tbl_instructors.instructor_id WHERE name = '" + FormLogin.username_display + "'";
                MySqlConnection conn1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(select_pic, conn1);
                MySqlDataAdapter da_pic = new MySqlDataAdapter(commandDatabase);
                DataTable dt_pic = new DataTable();
                da_pic.Fill(dt_pic);

                byte[] pic = (byte[])dt_pic.Rows[0][0];
                MemoryStream ms = new MemoryStream(pic);
                picInstructor.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAddSched_Click(object sender, EventArgs e)
        {
            PopSchedule dialog = new PopSchedule();
            dialog.ShowDialog();
            LoadSchedules();
        }

        private async Task LoadSchedules()
        {
            try
            {
                string loadschedules_query = "SELECT tbl_schedule.schedule_id, tbl_schedule.schedule_name, CONCAT(start_hour, ':', start_minute) AS start_time, CONCAT(end_hour, ':', end_minute) AS end_time, section_year, day, room FROM tbl_schedule JOIN tbl_instructors ON tbl_schedule.instructor_id = tbl_instructors.instructor_id WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '" + FormLogin.username_display + "' ORDER BY start_time ASC";

                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(loadschedules_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sectionYear", FormLogin.advisory_display);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            await Task.Run(() =>
                            {
                                da.Fill(dt);
                            });
                        }
                    }
                }

                dgvSchedules.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete schedule?", "Delete Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selected_scheduleid = dgvSchedules.CurrentRow.Cells["schedule_id"].Value.ToString();

                try
                {
                    string delete_row = "DELETE from tbl_schedule where schedule_id= '" + selected_scheduleid + "'";
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    MySqlCommand cmd = new MySqlCommand(delete_row, conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadSchedules();
            DefaultButtons();
        }

        public class User
        {
            public string user_id { get; set; }
            public string user_type { get; set; }
            public string firstname { get; set; }
            public string middlename { get; set; }
            public string lastname { get; set; }
            public string card_id { get; set; }
            public string section { get; set; }
            public string picture { get; set; }
        }

        private async Task ShowInstructorStatsGraphHours()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string SummaryQuery = $@"
                        SELECT view_total_class_hours.* FROM view_total_class_hours
                        JOIN tbl_instructors ON view_total_class_hours.Instructor_ID = tbl_instructors.instructor_id
                        WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '{FormLogin.username_display}';
                    ";

                    using (MySqlCommand command = new MySqlCommand(SummaryQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable HoursTable = new DataTable();
                            HoursTable.Load(reader);
                            PopulateChartWithHours(HoursTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ShowInstructorStatsGraphAttendance()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string SummaryQuery = $@"
                        SELECT view_total_conducted_classes.Instructor_ID, view_total_conducted_classes.Schedule, view_total_conducted_classes.Section, Total_Conducted_Classes, COALESCE(Total_Attendance, 0) AS Total_Attendance FROM view_total_conducted_classes
                        LEFT JOIN view_total_class_attendance on view_total_conducted_classes.Schedule = view_total_class_attendance.Schedule
                        JOIN tbl_instructors ON view_total_conducted_classes.Instructor_ID = tbl_instructors.instructor_id
                        WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '{FormLogin.username_display}';
                    ";

                    using (MySqlCommand command = new MySqlCommand(SummaryQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable AttendanceTable = new DataTable();
                            AttendanceTable.Load(reader);

                            AttendanceTable.Columns.Add("Enrolled_Students", typeof(int));
                            AttendanceTable.Columns.Add("Average_Attendance_Percentage", typeof(double));

                            string jsonContent = File.ReadAllText("localusers.json");
                            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                            foreach (DataRow row in AttendanceTable.Rows)
                            {
                                int studentSectionCount = 0;
                                foreach (User user in users)
                                {
                                    if (user.user_type.ToLower() == "student" && user.section == row["Section"].ToString())
                                    {
                                        studentSectionCount++;
                                    }
                                }
                                row["Enrolled_Students"] = studentSectionCount;

                                int enrolledstudents = Convert.ToInt32(row["Enrolled_Students"]);
                                int classes = Convert.ToInt32(row["Total_Conducted_Classes"]);
                                int totalattendance = Convert.ToInt32(row["Total_Attendance"]);

                                if (classes * enrolledstudents != 0)
                                {
                                    double percentage = ((double)totalattendance / (classes * enrolledstudents)) * 100;
                                    row["Average_Attendance_Percentage"] = percentage;
                                }
                                else
                                {
                                    row["Average_Attendance_Percentage"] = 0;
                                }
                            }
                            PopulateChartWithAttendance(AttendanceTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateChartWithAttendance(DataTable Table)
        {
            chrtInstructorGraph2.Series[0].Points.Clear();
            chrtInstructorGraph2.ChartAreas[0].AxisY.Maximum = 100;
            chrtInstructorGraph2.ChartAreas[0].AxisY.LabelStyle.Format = "{0}%";
            chrtInstructorGraph2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            foreach (DataRow row in Table.Rows)
            {
                string schedule = row["Schedule"].ToString();
                double attendancePercentage;
                if (double.TryParse(row["Average_Attendance_Percentage"].ToString(), out attendancePercentage))
                {
                    string formattedPercentage = attendancePercentage.ToString("N2");
                    chrtInstructorGraph2.Series[0].Points.AddXY(schedule, formattedPercentage);
                }
                else
                {
                    
                }
            }
        }

        private void PopulateChartWithHours(DataTable Table)
        {
            chrtInstructorGraph1.Series[0].Points.Clear();
            chrtInstructorGraph1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            foreach (DataRow row in Table.Rows)
            {
                string schedule = row["Schedule"].ToString();
                double hours;
                if (double.TryParse(row["Total_Hours"].ToString(), out hours))
                {
                    string formattedhour = hours.ToString("N2");
                    chrtInstructorGraph1.Series[0].Points.AddXY(schedule, formattedhour);
                }
                else
                {

                }
            }
        }

        private void HideButtons()
        {
            btnDelete.Enabled = true;
        }

        private void DefaultButtons()
        {
            btnDelete.Enabled = false;
        }

        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HideButtons();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            PopGenerateDTR dialog = new PopGenerateDTR();
            dialog.ShowDialog();
        }
    }
}
