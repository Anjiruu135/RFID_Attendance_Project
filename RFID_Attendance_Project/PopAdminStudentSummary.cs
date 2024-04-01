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
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project
{
    public partial class PopAdminStudentSummary : Form
    {
        string connectionString = Database.connectionString;

        public PopAdminStudentSummary()
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

        private async void PopAdminStudentSummary_Load(object sender, EventArgs e)
        {
            await ShowSummary();
        }

        private async Task ShowSummary()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string classAttendanceQuery = "SELECT User_ID, Fullname, view_total_student_attendance.Section, Total_Attendance, Total_Classes_Section FROM view_total_student_attendance " +
                                                  "JOIN view_total_section_attendance on view_total_student_attendance.Section = view_total_section_attendance.Section  ";
                    using (MySqlCommand command = new MySqlCommand(classAttendanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Section", FormLogin.advisory_display);

                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable SummaryTable = new DataTable();
                            SummaryTable.Load(reader);

                            SummaryTable.Columns.Add("Average_Attendance_Percentage", typeof(double));

                            foreach (DataRow row in SummaryTable.Rows)
                            {
                                int totalStudentAttendance = Convert.ToInt32(row["Total_Attendance"]);
                                int totalClassesConducted = Convert.ToInt32(row["Total_Classes_Section"]);
                                double studentPercentage = ((double)totalStudentAttendance / totalClassesConducted) * 100;
                                row["Average_Attendance_Percentage"] = studentPercentage;
                            }
                            dgvSummaryResult.Columns["Average_Attendance_Percentage"].DefaultCellStyle.Format = "N2";
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
