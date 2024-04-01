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
    public partial class PopAdminInstructorSummary : Form
    {
        string connectionString = Database.connectionString;

        public PopAdminInstructorSummary()
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

        private async Task ShowSummary()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string ClassAttendanceQuery = $@"
                        SELECT CONCAT(lastname, ', ',firstname) as Instructor_Name, view_total_conducted_classes.*, Total_Hours FROM view_total_conducted_classes
                        JOIN view_total_class_hours ON view_total_conducted_classes.Schedule = view_total_class_hours.Schedule
                        JOIN tbl_instructors ON view_total_conducted_classes.Instructor_ID = tbl_instructors.instructor_id;
                    ";

                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable AttendanceTable = new DataTable();
                            AttendanceTable.Load(reader);
                            dgvSummaryResult.DataSource = AttendanceTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ShowSchedules()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string ClassAttendanceQuery = $@"
                        SELECT CONCAT(lastname, ', ',firstname) as instructor_name, tbl_schedule.* FROM tbl_schedule
                        JOIN tbl_instructors ON tbl_schedule.instructor_id = tbl_instructors.instructor_id;
                    ";

                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable AttendanceTable = new DataTable();
                            AttendanceTable.Load(reader);
                            dgvSummaryResult.DataSource = AttendanceTable;
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
            if (cmbCategory.Text == "Summary")
            {
                await ShowSummary();
            }
            else if (cmbCategory.Text == "Schedules")
            {
                await ShowSchedules();
            }
            else
            {
                dgvSummaryResult.DataSource = null;
            }
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
                    DataTable dt = Excel.DataGridView_To_Datatable(dgvSummaryResult);
                    dt.exportToExcel(openFileDialog.FileName);
                    MessageBox.Show("Table exported successfully", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            dgvSummaryResult.DataSource = null;
        }
    }
}
