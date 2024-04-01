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
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using System.Data.Common;
using System.IO;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_UserAttendance : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_UserAttendance()
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

        private async Task Classes()
        {
            string loadschedules_query = "SELECT SUBSTRING_INDEX(schedule_id, ':', 1) AS class_name FROM tbl_schedule JOIN tbl_instructors ON tbl_schedule.instructor_id = tbl_instructors.instructor_id WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = @Instructor GROUP BY SUBSTRING_INDEX(schedule_id, ':', 1) ORDER BY schedule_id ASC";

            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(loadschedules_query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Instructor", FormLogin.username_display);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            await Task.Run(() =>
                            {
                                da.Fill(dt);
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            dgvClassList.DataSource = dt;
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
        string holdClassSection;

        private void CountStudentsJSON()
        {
            try
            {
                string jsonContent = File.ReadAllText("localusers.json");

                List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                int studentRowCount = 0;

                foreach (User user in users)
                {
                    if (user.user_type.ToLower() == "student" && user.section == holdClassSection)
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

        public static int PublicTotalStudents;
        public static int PublicTotalDays;
        public static string PublicClassSection;

        private async Task ShowGraphs()
        {
            string selected_class = dgvClassList.CurrentRow.Cells["class_name"].Value.ToString();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    List<int> studentCounts = new List<int>();
                    int totalDays = 0;
                    chartStudentsPerClass.Series[0].Points.Clear();

                    await connection.OpenAsync();
                    string ClassAttendanceQuery = $@"
                        SELECT DATE_FORMAT(STR_TO_DATE(date, '%W, %M %e, %Y'), '%Y-%m-%d') AS numerical_date, COUNT(DISTINCT fullname) AS students, section
                        FROM tbl_classattendance 
                        JOIN view_attendance_users ON tbl_classattendance.user_id = view_attendance_users.user_id 
                        WHERE user_type = 'student' AND schedule_id LIKE '{selected_class}%'
                        GROUP BY schedule_id, numerical_date
                        ORDER BY numerical_date ASC;
                    ";

                    // STUDENTS PER CLASS SESSION CHART
                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                holdClassSection = reader["section"].ToString();
                                int students = Convert.ToInt32(reader["students"]);
                                studentCounts.Add(students);
                                totalDays++;
                                string date = reader["numerical_date"].ToString();
                                chartStudentsPerClass.Series[0].Points.AddXY(date, students);
                            }
                        }
                    }

                    CountStudentsJSON();

                    // AVERAGE AND HIGHEST AND LOWEST PERCENTAGE STATS
                    double totalStudents = studentCounts.Sum();
                    double averageAbsencePercentage = (1 - (totalStudents / (totalDays * enrolled_students))) * 100;
                    int highestAbsenceCount = studentCounts.Min();
                    double highestAbsencePercentage = (1 - ((double)highestAbsenceCount / enrolled_students)) * 100;

                    chartTotalClasses.Series.Clear();
                    Series series_totalclasses = chartTotalClasses.Series.Add("TotalClasses");
                    series_totalclasses.ChartType = SeriesChartType.Pie;
                    series_totalclasses.Points.Clear();
                    series_totalclasses.Points.AddY(totalDays);
                    series_totalclasses.Points[0].Label = "";

                    chartTotalStudents.Series.Clear();
                    Series series_totalstudents = chartTotalStudents.Series.Add("TotalStudents");
                    series_totalstudents.ChartType = SeriesChartType.Pie;
                    series_totalstudents.Points.Clear();
                    series_totalstudents.Points.AddY(enrolled_students);
                    series_totalstudents.Points[0].Label = "";

                    lblTotalClasses.Text = $"{totalDays} Days";
                    lblTotalStudents.Text = $"{enrolled_students} Students";
                    lblTotalClasses.Visible = true;
                    lblTotalStudents.Visible = true;

                    chartAveragePercent.Series.Clear();
                    Series series_average = chartAveragePercent.Series.Add("AveragePercentage");
                    series_average.ChartType = SeriesChartType.Doughnut;
                    series_average.Points.Clear();
                    series_average.Points.AddY(averageAbsencePercentage);
                    series_average.Points.AddY(100 - averageAbsencePercentage);
                    series_average.Points[1].Label = "Average Present : #VALY{0.00}%";
                    series_average.Points[0].Label = "Average Absent : #VALY{0.00}%";

                    chartHighestPercent.Series.Clear();
                    Series series_highest = chartHighestPercent.Series.Add("HighLowPercentage");
                    series_highest.ChartType = SeriesChartType.Doughnut;
                    series_highest.Points.Clear();
                    series_highest.Points.AddY(highestAbsencePercentage);
                    series_highest.Points.AddY(100 - highestAbsencePercentage);
                    series_highest.Points[1].Label = "Lowest Present : #VALY{0.00}%";
                    series_highest.Points[0].Label = "Highest Absent : #VALY{0.00}%";

                    // STUDENTS WITH HIGHEST ABSENTS
                    string SchoolAttendanceQuery = $@"
                        SELECT CONCAT(view_attendance_users.lastname, ', ', view_attendance_users.firstname) as fullname, 
                        COALESCE(COUNT(DISTINCT tbl_classattendance.schedule_id), 0) AS attendance 
                        FROM view_attendance_users 
                        LEFT JOIN tbl_classattendance ON tbl_classattendance.user_id = view_attendance_users.user_id 
                        AND tbl_classattendance.schedule_id LIKE '{selected_class}%' 
                        WHERE view_attendance_users.user_type = 'student' AND view_attendance_users.section = '{holdClassSection}'
                        GROUP BY view_attendance_users.user_id 
                        ORDER BY attendance DESC 
                        LIMIT 6;
                    ";

                    using (MySqlCommand command = new MySqlCommand(SchoolAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            chartMostAbsents.Series[0].Points.Clear();

                            while (await reader.ReadAsync())
                            {
                                int attendance = Convert.ToInt32(reader["attendance"]);
                                int absents = totalDays - attendance;
                                string fullname = reader["fullname"].ToString();
                                chartMostAbsents.Series[0].Points.AddXY(fullname, absents);
                            }
                        }
                    }

                    PublicTotalStudents = enrolled_students;
                    PublicClassSection = holdClassSection;
                    PublicTotalDays = totalDays;
                }
            }
            catch (Exception ex)
            {
                chartAveragePercent.Series.Clear();
                chartHighestPercent.Series.Clear();
                chartMostAbsents.Series[0].Points.Clear();
                chartTotalClasses.Series.Clear();
                chartTotalStudents.Series.Clear();
                lblTotalClasses.Visible = false;
                lblTotalStudents.Visible = false;
                PublicSelectedClass = "";
            }
        }

        private async void UC_UserAttendance_Load(object sender, EventArgs e)
        {
            await Classes();
        }

        private async void dgvClassList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowGraphs();
                btnViewAttendanceDetails.Enabled = true;
            }
        }

        public static string PublicSelectedClass;

        private void btnViewAttendanceDetails_Click(object sender, EventArgs e)
        {
            PublicSelectedClass = dgvClassList.CurrentRow.Cells["class_name"].Value.ToString();
            PopAttendanceDetails dialog = new PopAttendanceDetails();
            dialog.ShowDialog();
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            PopAttendanceSummary dialog = new PopAttendanceSummary();
            dialog.ShowDialog();
        }
    }
}
