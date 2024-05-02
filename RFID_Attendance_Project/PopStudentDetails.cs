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
using MySql.Data.MySqlClient;
using RFID_Attendance_Project.Modules;
using OfficeOpenXml;

namespace RFID_Attendance_Project
{
    public partial class PopStudentDetails : Form
    {
        string connectionString = Database.connectionString;

        public PopStudentDetails()
        {
            InitializeComponent();
            lblSection.Text = FormLogin.advisory_display;
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

        private async void PopStudentDetails_Load(object sender, EventArgs e)
        {
            await LoadStudents();
        }

        DataTable dt = new DataTable();

        private async Task LoadStudents()
        {
            try
            {
                string loadStudentsQuery = "SELECT student_id, tbl_students.firstname, tbl_students.middlename, tbl_students.lastname, tbl_students.card_id,  tbl_students.contact, parent_contact FROM tbl_students JOIN tbl_instructors ON tbl_students.section_year = tbl_instructors.advisory WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = @Username";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(loadStudentsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", FormLogin.username_display);
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    dgvDetailsResult.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvDetailsResult);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("firstname LIKE '%{0}%' OR middlename LIKE '%{0}%' OR lastname LIKE '%{0}%'  OR student_id LIKE '%{0}%'", textBox1.Text);
        }
    }
}
