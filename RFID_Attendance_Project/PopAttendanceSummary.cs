using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace RFID_Attendance_Project
{
    public partial class PopAttendanceSummary : Form
    {
        string connectionString = Database.connectionString;

        public PopAttendanceSummary()
        {
            InitializeComponent();
            lblInstrutor.Text = FormLogin.username_display;
            lblAdvisory.Text = FormLogin.advisory_display;
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

        private async void PopAttendanceSummary_Load(object sender, EventArgs e)
        {
            await ShowSummary();
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

        private async Task ShowSummary()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string SummaryQuery = $@"
                        SELECT view_conducted_classes.schedule_id as Schedule, view_conducted_classes.section_year as Section, view_conducted_classes.room as Room, view_conducted_classes.conducted_classes as Classes_Conducted, COALESCE(SUM(view_class_attendance.students), 0) as Total_Attendance 
                        FROM view_conducted_classes
                        LEFT JOIN view_class_attendance ON view_conducted_classes.schedule_id = view_class_attendance.schedule_id
                        JOIN tbl_instructors ON view_conducted_classes.instructor_id = tbl_instructors.instructor_id
                        WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '{FormLogin.username_display}'
                        GROUP BY view_conducted_classes.schedule_id;
                    ";

                    using (MySqlCommand command = new MySqlCommand(SummaryQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable SummaryTable = new DataTable();
                            SummaryTable.Load(reader);

                            SummaryTable.Columns.Add("Enrolled_Students", typeof(int));
                            SummaryTable.Columns.Add("Average_Attendance_Percentage", typeof(double));

                            string jsonContent = File.ReadAllText("localusers.json");
                            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                            foreach (DataRow row in SummaryTable.Rows)
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
                                int classes = Convert.ToInt32(row["Classes_Conducted"]);
                                int totalattendance = Convert.ToInt32(row["Total_Attendance"]);

                                if (classes * enrolledstudents != 0)
                                {
                                    double percentage = ((double)totalattendance / (classes * enrolledstudents)) * 100;
                                    row["Average_Attendance_Percentage"] = Math.Round(percentage, 2);
                                }
                                else
                                {
                                    row["Average_Attendance_Percentage"] = 0;
                                }
                            }
                            dgvSummaryResult.DataSource = SummaryTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
