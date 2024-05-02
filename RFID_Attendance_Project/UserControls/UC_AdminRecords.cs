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
using OfficeOpenXml;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_AdminRecords : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_AdminRecords()
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

        private void UC_AdminRecords_Load(object sender, EventArgs e)
        {
            dateTimePicker.MaxDate = DateTime.Today;
            dateTimePicker.Value = DateTime.Today;
        }

        private async void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;
            string formattedDate = selectedDate.ToString("dddd, MMMM d, yyyy");
            await showRecords(formattedDate);
            await showRecent();
            await ShowGraph();
        }

        private async Task showRecords(string SelectedDate)
        {
            try
            {
                string loadRecordsQuery = "SELECT * FROM tbl_schoolattendance WHERE date = @Dateselected GROUP BY fullname, date ORDER BY time_in ASC;";
                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(loadRecordsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Dateselected", SelectedDate);
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    dgvRecords.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class JSONUsers
        {
            public string user_id { get; set; }
            public string user_type { get; set; }
            public string firstname { get; set; }
            public string middlename { get; set; }
            public string lastname { get; set; }
            public string card_id { get; set; }
            public string section { get; set; }
            public byte[] picture { get; set; }
        }

        public string recentIn_ID;
        public string recentOut_ID;
        public string fullname_display;

        private async Task showRecent()
        {
            DateTime selectedDate = DateTime.Today;
            string DateNow = selectedDate.ToString("dddd, MMMM d, yyyy");

            var jsonData = File.ReadAllText("users.json");
            var students = JsonConvert.DeserializeObject<List<JSONUsers>>(jsonData);

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                                    new DataColumn("user_id", typeof(string)),
                                    new DataColumn("user_type", typeof(string)),
                                    new DataColumn("firstname", typeof(string)),
                                    new DataColumn("middlename", typeof(string)),
                                    new DataColumn("lastname", typeof(string)),
                                    new DataColumn("card_id", typeof(string)),
                                    new DataColumn("section", typeof(string)),
                                    new DataColumn("picture", typeof(byte[])),
            });

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string RecentTimeInQuery = $"SELECT * FROM tbl_schoolattendance WHERE date = '{DateNow}' GROUP BY fullname, date ORDER BY time_in DESC LIMIT 1;";
                    using (MySqlCommand command = new MySqlCommand(RecentTimeInQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                fullname_display = reader["fullname"].ToString();
                                lblTimeIn.Text = fullname_display;
                                recentIn_ID = reader["user_id"].ToString();

                                foreach (var student in students)
                                {
                                    if (student.user_id == recentIn_ID)
                                    {
                                        dt.Rows.Add(
                                            student.user_id,
                                            student.user_type,
                                            student.firstname,
                                            student.middlename,
                                            student.lastname,
                                            student.card_id,
                                            student.section,
                                            student.picture
                                        );
                                    }
                                }

                                DataRow row = dt.Rows[0];
                                string taken_id = row["user_id"].ToString();

                                byte[] pic = (byte[])row["picture"];
                                MemoryStream ms = new MemoryStream(pic);
                                picTimeIn.Image = Image.FromStream(ms);
                            }
                        }
                    }

                    string RecentTimeOutQuery = $"SELECT * FROM tbl_schoolattendance WHERE date = '{DateNow}' GROUP BY fullname, date ORDER BY time_out DESC LIMIT 1;";
                    using (MySqlCommand command = new MySqlCommand(RecentTimeOutQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                fullname_display = reader["fullname"].ToString();
                                lblTimeOut.Text = fullname_display;
                                recentIn_ID = reader["user_id"].ToString();

                                foreach (var student in students)
                                {
                                    if (student.user_id == recentIn_ID)
                                    {
                                        dt.Rows.Add(
                                            student.user_id,
                                            student.user_type,
                                            student.firstname,
                                            student.middlename,
                                            student.lastname,
                                            student.card_id,
                                            student.section,
                                            student.picture
                                        );
                                    }
                                }

                                DataRow row = dt.Rows[0];
                                string taken_id = row["user_id"].ToString();

                                byte[] pic = (byte[])row["picture"];
                                MemoryStream ms = new MemoryStream(pic);
                                picTimeOut.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ShowGraph()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    chartAttendanceHistory.Series[0].Points.Clear();

                    await connection.OpenAsync();
                    string ClassAttendanceQuery = "SELECT COUNT(fullname) as count, date FROM view_school_attendance GROUP BY date;";

                    using (MySqlCommand command = new MySqlCommand(ClassAttendanceQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int count = Convert.ToInt32(reader["count"]);
                                string date = reader["date"].ToString();
                                chartAttendanceHistory.Series[0].Points.AddXY(date, count);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvRecords);
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
    }
}
