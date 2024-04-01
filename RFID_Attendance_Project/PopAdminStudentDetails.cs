﻿using System;
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

namespace RFID_Attendance_Project
{
    public partial class PopAdminStudentDetails : Form
    {
        string connectionString = Database.connectionString;

        public PopAdminStudentDetails()
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

        private async void PopAdminStudentDetails_Load(object sender, EventArgs e)
        {
            await LoadStudents();
        }

        private async Task LoadStudents()
        {
            try
            {
                string loadStudentsQuery = "SELECT student_id ,firstname, middlename, lastname, section_year, card_id,  contact, parent_contact FROM tbl_students";
                DataTable dt = new DataTable();

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