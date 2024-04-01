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
    public partial class PopChangePassword : Form
    {
        string connectionString = Database.connectionString;

        public PopChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            var passwordModel = CreatePasswordModelFromForm();

            if (!ValidatePasswordModel(passwordModel))
            {
                DisplayValidationErrors(passwordModel);
                return;
            }
            else
            {
                if (!IsCurrentPasswordCorrect(txtPasswordCurrent.Text))
                {
                    MessageBox.Show("Incorrect Current Password", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change the password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string change_password = "UPDATE tbl_users SET `password`=@NewPassword WHERE user_id = 'admin';";
                        MySqlConnection conn = new MySqlConnection(connectionString);
                        MySqlCommand cmd = new MySqlCommand(change_password, conn);

                        cmd.Parameters.AddWithValue("@NewPassword", txtPasswordNew.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Password Changed Successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private Password CreatePasswordModelFromForm()
        {
            return new Password()
            {
                CurrentPassword = txtPasswordCurrent.Text,
                NewPassword = txtPasswordNew.Text,
                ConfirmNewpassword = txtPasswordConfirm.Text,
            };
        }

        private bool ValidatePasswordModel(Password passwordModel)
        {
            ValidationContext context = new ValidationContext(passwordModel);
            IList<ValidationResult> errs = new List<ValidationResult>();

            return Validator.TryValidateObject(passwordModel, context, errs, true);
        }

        private void DisplayValidationErrors(Password passwordModel)
        {
            ValidationContext context = new ValidationContext(passwordModel);
            IList<ValidationResult> errs = new List<ValidationResult>();
            Validator.TryValidateObject(passwordModel, context, errs, true);

            StringBuilder errorMsg = new StringBuilder();
            foreach (ValidationResult res in errs)
                errorMsg.AppendLine(res.ErrorMessage);
            MessageBox.Show(errorMsg.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsCurrentPasswordCorrect(string password)
        {
            string query = "SELECT * from tbl_users WHERE user_id='admin' and password=@Password";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}
