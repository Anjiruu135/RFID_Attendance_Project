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
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms.DataVisualization.Charting;
using RFID_Attendance_Project.Models;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_AdminInstructors : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_AdminInstructors()
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

        private async void UC_AdminInstructors_Load(object sender, EventArgs e)
        {
            LoadInstructors();
            await LoadDepartments(cmbDepartment);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var instructorModel = CreateInstructorModelFromForm();

            if (!ValidateInstructorModel(instructorModel))
            {
                DisplayValidationErrors(instructorModel);
                return;
            }

            else if (!ValidatePictureBoxImage(picInstructor))
            {
                MessageBox.Show("Please select an image for the instructor.", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                if (IsInstructorIdTaken(txtInstructorId.Text))
                {
                    MessageBox.Show("Instructor ID already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (IsRFIDTaken(txtRFID.Text))
                {
                    MessageBox.Show("RFID already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (IsAdvisoryTaken(txtAdvisory.Text))
                {
                    MessageBox.Show("Advisory already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        picInstructor.Image.Save(ms, picInstructor.Image.RawFormat);
                        byte[] pic = ms.ToArray();

                        string add_instructor = "INSERT INTO `tbl_instructors`(`instructor_id`, `firstname`, `middlename`, `lastname`, `advisory`, `department`, `card_id`, `contact`, `picture`) VALUES (@InstructorId, @Firstname, @Middlename, @Lastname, @Advisory, @Department, @RFID, @Contact, @Picture)";
                        MySqlConnection conn = new MySqlConnection(connectionString);
                        MySqlCommand cmd = new MySqlCommand(add_instructor, conn);

                        cmd.Parameters.AddWithValue("@InstructorId", txtInstructorId.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Advisory", txtAdvisory.Text);
                        cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                        cmd.Parameters.AddWithValue("@RFID", txtRFID.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Picture", pic);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string add_user = "INSERT INTO `tbl_users`(`user_id`, `password`, `name`, `user_type`) VALUES (@UserId, @Password, @Name, 'user')";
                        MySqlCommand cmd_user = new MySqlCommand(add_user, conn);

                        cmd_user.Parameters.AddWithValue("@UserId", txtInstructorId.Text);
                        cmd_user.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd_user.Parameters.AddWithValue("@Name", txtLastName.Text + ", " + txtFirstName.Text);

                        conn.Open();
                        cmd_user.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("New instructor added successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    LoadInstructors();
                    ClearForm();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var instructorModel = CreateInstructorModelFromForm();

            if (!ValidateInstructorModel(instructorModel))
            {
                DisplayValidationErrors(instructorModel);
                return;
            }
            else if (!ValidatePictureBoxImage(picInstructor))
            {
                MessageBox.Show("Please select an image for the instructor.", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (IsRFIDTakenForUpdate(txtRFID.Text))
                {
                    MessageBox.Show("RFID already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        string selected_instructorid = dgvInstructorList.CurrentRow.Cells["instructor_id"].Value.ToString();

                        string update_instructor = "UPDATE `tbl_instructors` SET `instructor_id`=@InstructorId,`firstname`=@Firstname,`middlename`=@Middlename,`lastname`=@Lastname,`advisory`=@Advisory,`department`=@Department,`card_id`=@RFID,`contact`=@Contact WHERE instructor_id='" + selected_instructorid + "'";
                        MySqlConnection conn = new MySqlConnection(connectionString);
                        MySqlCommand cmd = new MySqlCommand(update_instructor, conn);

                        cmd.Parameters.AddWithValue("@InstructorId", txtInstructorId.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Advisory", txtAdvisory.Text);
                        cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                        cmd.Parameters.AddWithValue("@RFID", txtRFID.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string update_user = "UPDATE `tbl_users` SET `user_id`=@UserId,`password`=@Password, `name`=@Name WHERE user_id='" + selected_instructorid + "'";
                        MySqlCommand cmd_user = new MySqlCommand(update_user, conn);

                        cmd_user.Parameters.AddWithValue("@UserId", txtInstructorId.Text);
                        cmd_user.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd_user.Parameters.AddWithValue("@Name", txtLastName.Text + ", " + txtFirstName.Text);

                        conn.Open();
                        cmd_user.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Instructor updated successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    LoadInstructors();
                    ClearForm();
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string randomCode = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            txtPassword.Text = randomCode;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                btnShow.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShow.Text = "Show";
            }
        }

        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            UploadPicture();
        }

        private void btnChangePic_Click(object sender, EventArgs e)
        {
            UploadPicture();

            string selected_instructorid = dgvInstructorList.CurrentRow.Cells["instructor_id"].Value.ToString();

            MemoryStream ms = new MemoryStream();
            picInstructor.Image.Save(ms, picInstructor.Image.RawFormat);
            byte[] pic = ms.ToArray();

            string update_student_pic = "UPDATE `tbl_instructors` SET `picture`=@Pic WHERE `instructor_id`='" + selected_instructorid + "';";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(update_student_pic, conn);

            cmd.Parameters.AddWithValue("@Pic", pic);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void dgvInstructorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowInstructorStatsGraph();
                ShowInfo();
                HideButtons();
            }
        }

        private async Task LoadInstructors()
        {
            try
            {
                string loadinstructors_query = "SELECT tbl_instructors.*, tbl_users.password FROM tbl_instructors JOIN tbl_users ON tbl_instructors.instructor_id = tbl_users.user_id WHERE user_type='user';";
                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(loadinstructors_query, conn))
                    {
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    dgvInstructorList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInfo()
        {
            string selected_instructorid = dgvInstructorList.CurrentRow.Cells["instructor_id"].Value.ToString();
            string selected_lastname = dgvInstructorList.CurrentRow.Cells["lastname"].Value.ToString();
            string selected_firstname = dgvInstructorList.CurrentRow.Cells["firstName"].Value.ToString();
            string selected_middlename = dgvInstructorList.CurrentRow.Cells["middleName"].Value.ToString();
            string selected_advisory = dgvInstructorList.CurrentRow.Cells["advisory"].Value.ToString();
            string selected_department = dgvInstructorList.CurrentRow.Cells["department"].Value.ToString();
            string selected_rfid = dgvInstructorList.CurrentRow.Cells["card_id"].Value.ToString();
            string selected_contact = dgvInstructorList.CurrentRow.Cells["contact"].Value.ToString();
            string selected_password = dgvInstructorList.CurrentRow.Cells["password"].Value.ToString();

            DataGridViewImageCell imageCell = dgvInstructorList.CurrentRow.Cells["picture"] as DataGridViewImageCell;

            if (imageCell.Value != null && imageCell.Value is byte[])
            {
                byte[] imageData = (byte[])imageCell.Value;

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image selected_image = Image.FromStream(ms);
                    picInstructor.Image = selected_image;
                }
            }

            txtInstructorId.Text = selected_instructorid;
            txtFirstName.Text = selected_firstname;
            txtLastName.Text = selected_lastname;
            txtMiddleName.Text = selected_middlename;
            txtAdvisory.Text = selected_advisory;
            cmbDepartment.Text = selected_department;
            txtRFID.Text = selected_rfid;
            txtContact.Text = selected_contact;
            txtPassword.Text = selected_password;
        }

        private void UploadPicture()
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                picInstructor.Image = new Bitmap(openfd.FileName);
                picInstructor.ImageLocation = openfd.FileName;
                picInstructor.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void ClearForm()
        {
            txtInstructorId.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtAdvisory.Text = "";
            txtRFID.Text = "";
            txtContact.Text = "";
            picInstructor.Image = null;
            txtPassword.Text = "";
            DefaultButtons();
        }

        private Instructor CreateInstructorModelFromForm()
        {
            return new Instructor()
            {
                InstructorId = txtInstructorId.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Advisory = txtAdvisory.Text,
                Department = cmbDepartment.Text,
                CardId = txtRFID.Text,
                Contact = txtContact.Text,
                Password = txtPassword.Text,
            };
        }

        private bool ValidateInstructorModel(Instructor instructorModel)
        {
            ValidationContext context = new ValidationContext(instructorModel);
            IList<ValidationResult> errs = new List<ValidationResult>();

            return Validator.TryValidateObject(instructorModel, context, errs, true);
        }

        private void DisplayValidationErrors(Instructor instructorModel)
        {
            ValidationContext context = new ValidationContext(instructorModel);
            IList<ValidationResult> errs = new List<ValidationResult>();
            Validator.TryValidateObject(instructorModel, context, errs, true);

            StringBuilder errorMsg = new StringBuilder();
            foreach (ValidationResult res in errs)
                errorMsg.AppendLine(res.ErrorMessage);
            MessageBox.Show(errorMsg.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidatePictureBoxImage(PictureBox pictureBox)
        {
            return pictureBox.Image != null;
        }

        private bool IsInstructorIdTaken(string instructorId)
        {
            string query = "SELECT * FROM tbl_instructors WHERE instructor_id=@instructorId";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@instructorId", instructorId);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private bool IsRFIDTaken(string rfid)
        {
            string query = "SELECT * FROM view_attendance_users WHERE card_id=@rfid";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rfid", rfid);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private bool IsRFIDTakenForUpdate(string rfid)
        {
            string query = "SELECT * FROM view_attendance_users WHERE card_id=@rfid and user_id!=@userid;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rfid", rfid);
                    cmd.Parameters.AddWithValue("@userid", txtInstructorId.Text);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private bool IsAdvisoryTaken(string advisory)
        {
            string query = "SELECT * FROM tbl_instructors WHERE advisory=@Advisory";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Advisory", advisory);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void HideButtons()
        {
            btnDelete.Enabled = true;
            btnUpdate.Visible = true;
            btnChangePic.Visible = true;
            btnAdd.Visible = false;
            btnUploadPic.Visible = false;
            txtInstructorId.Enabled = false;
            txtAdvisory.Enabled = false;
        }

        private void DefaultButtons()
        {
            btnDelete.Enabled = false;
            btnUpdate.Visible = false;
            btnChangePic.Visible = false;
            btnAdd.Visible = true;
            btnUploadPic.Visible = true;
            txtInstructorId.Enabled = true;
            txtAdvisory.Enabled = true;
        }

        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private async Task LoadDepartments(ComboBox comboBox)
        {
            string loadstudents_query = "SELECT department FROM tbl_departments ORDER BY department ASC;";
            DataTable dt = new DataTable();

            await Task.Run(() =>
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(loadstudents_query, conn))
                    {
                        da.Fill(dt);
                    }
                }
            });

            cmbDepartment.DataSource = null;
            cmbDepartment.DataSource = dt;
            cmbDepartment.DisplayMember = "department";
            cmbDepartment.ValueMember = "department";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInstructor();
            LoadInstructors();
            ClearForm();
        }

        private void DeleteInstructor()
        {
            if (MessageBox.Show("Are you sure you want to delete instructor?", "Delete Instructor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selected_instructorid = dgvInstructorList.CurrentRow.Cells["instructor_id"].Value.ToString();

                string delete_row = "DELETE from tbl_instructors where instructor_id= '" + selected_instructorid + "'";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(delete_row, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private async Task ShowInstructorStatsGraph()
        {
            string selected_id = dgvInstructorList.CurrentRow.Cells["instructor_id"].Value.ToString();
            string selected_lastname = dgvInstructorList.CurrentRow.Cells["lastname"].Value.ToString();
            string selected_firstname = dgvInstructorList.CurrentRow.Cells["firstname"].Value.ToString();
            string name_format = $"{selected_lastname}, {selected_firstname}";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // INSTRUCTOR HOURS PER CLASS
                    string HourPerClass = $@"
                        SELECT view_total_class_hours.* FROM view_total_class_hours
                        JOIN tbl_instructors ON view_total_class_hours.Instructor_ID = tbl_instructors.instructor_id
                        WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '{name_format}';
                    ";
                    using (MySqlCommand command = new MySqlCommand(HourPerClass, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable HoursTable = new DataTable();
                            HoursTable.Load(reader);
                            PopulateChartWithHours(HoursTable);
                        }
                    }

                    // INSUTRUCTOR TOTAL HOURS
                    string InstructorTotalHours = $@"
                        SELECT Instructor_ID, SUM(Total_Hours) as Total_Hours
                        FROM view_total_class_hours
                        WHERE Instructor_ID = '{selected_id}'
                        GROUP BY Instructor_ID
                    ;";
                    using (MySqlCommand command = new MySqlCommand(InstructorTotalHours, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            chrtInstructorTotalHours.Series.Clear();
                            while (await reader.ReadAsync())
                            {
                                double totalhours = Convert.ToInt32(reader["Total_Hours"]);

                                Series series_totalstudents = chrtInstructorTotalHours.Series.Add("Total_Hours");
                                series_totalstudents.ChartType = SeriesChartType.Pie;
                                series_totalstudents.Points.Clear();
                                series_totalstudents.Points.AddY(totalhours);
                                series_totalstudents.Points[0].Label = "";
                                lblTotalHours.Visible = true;
                                lblTotalHours.Text = $"{totalhours} Hours";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                chrtInstructorHours.Series[0].Points.Clear();
                chrtInstructorTotalHours.Series.Clear();
                lblTotalHours.Visible = false;
            }
        }

        private void PopulateChartWithHours(DataTable Table)
        {
            chrtInstructorHours.Series[0].Points.Clear();
            chrtInstructorHours.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            foreach (DataRow row in Table.Rows)
            {
                string schedule = row["Schedule"].ToString();
                double hours;
                if (double.TryParse(row["Total_Hours"].ToString(), out hours))
                {
                    string formattedhour = hours.ToString("N2");
                    chrtInstructorHours.Series[0].Points.AddXY(schedule, formattedhour);
                }
                else
                {

                }
            }
        }

        private void btnViewInstructorDetails_Click(object sender, EventArgs e)
        {
            PopAdminInstructorDetails dialog = new PopAdminInstructorDetails();
            dialog.ShowDialog();
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            PopAdminInstructorSummary dialog = new PopAdminInstructorSummary();
            dialog.ShowDialog();
        }
    }
}
