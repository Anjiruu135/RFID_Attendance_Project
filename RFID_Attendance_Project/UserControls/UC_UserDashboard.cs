using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Windows.Forms.DataVisualization.Charting;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_UserDashboard : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_UserDashboard()
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

        private async void UC_UserDashboard_Load(object sender, EventArgs e)
        {
            lblAdvisory.Text = FormLogin.advisory_display;
            lblDate.Text = DateTime.Now.ToLongDateString();
            picEvents.SizeMode = PictureBoxSizeMode.StretchImage;
            StartCarousel();
            await LoadGraphs();
            await LoaduserSchedules();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer.Start();
        }

        private async Task LoaduserSchedules()
        {
            try
            {
                string loaddepartments_query = $"SELECT tbl_schedule.schedule_id FROM tbl_schedule JOIN tbl_instructors ON tbl_schedule.instructor_id = tbl_instructors.instructor_id WHERE day = '{DateTime.Now.DayOfWeek}' AND CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '{FormLogin.username_display}' ORDER BY start_hour ASC;";
                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(loaddepartments_query, conn))
                    {
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    dgvSchedules.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

            }
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

        int enrolled_students;
        int Total_Classes_Section;

        private void CountStudentsJSON()
        {
            try
            {
                string jsonContent = File.ReadAllText("localusers.json");

                List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                int studentRowCount = 0;

                foreach (User user in users)
                {
                    if (user.user_type.ToLower() == "student" && user.section == FormLogin.advisory_display)
                    {
                        studentRowCount++;
                    }
                }

                enrolled_students = studentRowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task LoadGraphs()
        {
            CountStudentsJSON();
            try
            {
                
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    await connection.OpenAsync();

                    // ADVISORY TOTAL STUDENTS AND PERCENTAGE
                    string AdvisoryAttendanceQuery = $"SELECT * FROM view_total_section_attendance WHERE Section = '{FormLogin.advisory_display}';";
                    using (MySqlCommand command = new MySqlCommand(AdvisoryAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Total_Classes_Section = Convert.ToInt32(reader["Total_Classes_Section"]);
                                int Total_Attendance_Section = Convert.ToInt32(reader["Total_Attendance_Section"]);
                                double Total_Percentage = ((double)Total_Attendance_Section / (Total_Classes_Section * enrolled_students)) * 100;
                                lblPercentage.Text = Total_Percentage.ToString("0.00") + "%";
                            }
                        }

                        lblTotalStudents.Text = $"{enrolled_students} Students";
                        lblPercentage.Visible = true;
                        lblTotalStudents.Visible = true;

                        chartTotalStudents.Series.Clear();
                        Series series_totalstudents = chartTotalStudents.Series.Add("TotalStudents");
                        series_totalstudents.ChartType = SeriesChartType.Pie;
                        series_totalstudents.Points.Clear();
                        series_totalstudents.Points.AddY(enrolled_students);
                        series_totalstudents.Points[0].Label = "";
                    }

                    // ADVISORY HIGHEST ABSENTS PERCENTAGE
                    string AdvisoryPercentageQuery = $"SELECT * FROM view_total_student_attendance  WHERE Section = '{FormLogin.advisory_display}' ORDER BY `view_total_student_attendance`.`Total_Attendance` ASC LIMIT 6;";
                    using (MySqlCommand command = new MySqlCommand(AdvisoryPercentageQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            chartStudentMostAbsent.Series[0].Points.Clear();
                            chartStudentMostAbsent.ChartAreas[0].AxisY.Maximum = 100;
                            chartStudentMostAbsent.ChartAreas[0].AxisY.LabelStyle.Format = "{0}%";
                            chartStudentMostAbsent.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

                            while (await reader.ReadAsync())
                            {
                                string fullname = reader["fullname"].ToString();
                                int Total_Attendance = Convert.ToInt32(reader["Total_Attendance"]);
                                double Student_Percentage = (1 - ((double)Total_Attendance / Total_Classes_Section)) * 100;
                                chartStudentMostAbsent.Series[0].Points.AddXY(fullname, Student_Percentage);
                            }
                        }
                    }

                    // COUNT STUDENTS INSIDE
                    string studentCountQuery = $"SELECT COUNT(DISTINCT fullname) as students_inside FROM tbl_schoolattendance JOIN view_attendance_users ON tbl_schoolattendance.user_id = view_attendance_users.user_id WHERE user_type = 'student' AND time_out = '' AND date = '{DateTime.Now.ToLongDateString()}' AND section = '{FormLogin.advisory_display}';";
                    using (MySqlCommand command = new MySqlCommand(studentCountQuery, connection))
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        DataTable CountTable = new DataTable();
                        CountTable.Load(reader);
                        if (CountTable.Rows.Count > 0)
                        {
                            lblNoStudents.Text = CountTable.Rows[0]["students_inside"].ToString();
                        }
                        else
                        {
                            lblNoStudents.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private DataTable imageDataTable;
        private int currentIndex = 0;

        private void StartCarousel()
        {
            imageDataTable = FetchImageDataFromJson();
            DisplayCurrentImage();

            timerCarousel.Interval = 6000;
            timerCarousel.Tick += timerCarousel_Tick;
            timerCarousel.Start();
        }

        private void timerCarousel_Tick(object sender, EventArgs e)
        {
            if (imageDataTable.Rows.Count > 0)
            {
                currentIndex = (currentIndex + 1) % imageDataTable.Rows.Count;
                DisplayCurrentImage();
            }
            else
            {
                currentIndex = 0;
            }
        }


        private DataTable FetchImageDataFromJson()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string jsonFilePath = "eventpics.json";
                string jsonData = File.ReadAllText(jsonFilePath);
                dataTable = JsonConvert.DeserializeObject<DataTable>(jsonData);
            }
            catch (Exception ex)
            {

            }

            return dataTable;
        }

        private void DisplayCurrentImage()
        {
            try
            {
                if (imageDataTable != null && imageDataTable.Rows.Count > 0)
                {
                    string base64ImageData = imageDataTable.Rows[currentIndex]["event_pic"].ToString();
                    byte[] imageData = Convert.FromBase64String(base64ImageData);
                    picEvents.Image = Image.FromStream(new MemoryStream(imageData));
                }
                else
                {
                    picEvents.Image = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
