using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Attendance_Project.Models;
using RFID_Attendance_Project.Modules;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project
{
    public partial class PopDepartment : Form
    {
        string connectionString = Database.connectionString;

        public PopDepartment()
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

        private Department CreateDepartmentModelFromForm()
        {
            return new Department()
            {
                Dept_ID = txtDepartment.Text,
                Dept_email = txtDeptEmail.Text,
            };
        }

        private bool ValidateDepartmentModel(Department departmentModel)
        {
            ValidationContext context = new ValidationContext(departmentModel);
            IList<ValidationResult> errs = new List<ValidationResult>();

            return Validator.TryValidateObject(departmentModel, context, errs, true);
        }

        private void DisplayValidationErrors(Department departmentModel)
        {
            ValidationContext context = new ValidationContext(departmentModel);
            IList<ValidationResult> errs = new List<ValidationResult>();
            Validator.TryValidateObject(departmentModel, context, errs, true);

            StringBuilder errorMsg = new StringBuilder();
            foreach (ValidationResult res in errs)
                errorMsg.AppendLine(res.ErrorMessage);
            MessageBox.Show(errorMsg.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsDepartmentIdTaken(string departmentID)
        {
            string query = "SELECT * FROM tbl_departments WHERE department=@DepartmentID";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var departmentModel = CreateDepartmentModelFromForm();

            if (!ValidateDepartmentModel(departmentModel))
            {
                DisplayValidationErrors(departmentModel);
                return;
            }
            else
            {
                if (IsDepartmentIdTaken(txtDepartment.Text))
                {
                    MessageBox.Show("Department already added", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    try
                    {
                        string add_department = "INSERT INTO `tbl_departments`(`department`, `dept_email`) VALUES (@DeptID,@DeptEmail)";
                        MySqlCommand cmd = new MySqlCommand(add_department, conn);

                        cmd.Parameters.AddWithValue("@DeptID", txtDepartment.Text);
                        cmd.Parameters.AddWithValue("@DeptEmail", txtDeptEmail.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("New department added successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
