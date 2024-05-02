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
using OfficeOpenXml;

namespace RFID_Attendance_Project
{
    public partial class PopAdminInstructorSummary : Form
    {
        string connectionString = Database.connectionString;

        public PopAdminInstructorSummary()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
            ExportToExcel(dgvSummaryResult);
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    for (int i = 1; i <= dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        excelPackage.SaveAs(new System.IO.FileInfo(filePath));
                        MessageBox.Show("Export Successful!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.Text = "";
            dgvSummaryResult.DataSource = null;
        }
    }
}
