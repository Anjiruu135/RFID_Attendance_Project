using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms.DataVisualization.Charting;
using RFID_Attendance_Project.Models;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_UserStudents : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_UserStudents()
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

        private void UC_UserStudents_Load(object sender, EventArgs e)
        {
            LoadStudents();
            txtSecYear.Text = FormLogin.advisory_display;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var studentModel = CreateStudentModelFromForm();

            if (!ValidateStudentModel(studentModel))
            {
                DisplayValidationErrors(studentModel);
                return;
            }

            else if (!ValidatePictureBoxImage(picStudent))
            {
                MessageBox.Show("Please select an image for the student.", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                if (IsStudentIdTaken(txtStudentId.Text))
                {
                    MessageBox.Show("Student ID already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (IsRFIDTaken(txtRFID.Text))
                {
                    MessageBox.Show("RFID already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                        byte[] pic = ms.ToArray();

                        string add_student = "INSERT INTO `tbl_students` (`student_id`, `firstname`, `middlename`, `lastname`, `section_year`, `card_id`, `contact`, `parent_contact`, `picture`) VALUES (@StudentId, @FirstName, @MiddleName, @LastName, @SecYear, @RFID, @Contact, @ParentContact, @Picture)";
                        MySqlConnection conn = new MySqlConnection(connectionString);
                        MySqlCommand cmd = new MySqlCommand(add_student, conn);

                        cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@SecYear", txtSecYear.Text);
                        cmd.Parameters.AddWithValue("@RFID", txtRFID.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@ParentContact", txtParentContact.Text);
                        cmd.Parameters.AddWithValue("@Picture", pic);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("New student added successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var studentModel = CreateStudentModelFromForm();

            if (!ValidateStudentModel(studentModel))
            {
                DisplayValidationErrors(studentModel);
                return;
            }
            else if (!ValidatePictureBoxImage(picStudent))
            {
                MessageBox.Show("Please select an image for the student.", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();

                        string update_student = "UPDATE `tbl_students` SET `student_id`=@StudentId,`firstname`=@FirstName,`middlename`=@MiddleName,`lastname`=@LastName,`section_year`=@SecYear,`card_id`=@RFID,`contact`=@Contact,`parent_contact`=@ParentContact WHERE `student_id`='" + selected_studentid + "';";
                        MySqlConnection conn = new MySqlConnection(connectionString);
                        MySqlCommand cmd = new MySqlCommand(update_student, conn);

                        cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@SecYear", txtSecYear.Text);
                        cmd.Parameters.AddWithValue("@RFID", txtRFID.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@ParentContact", txtParentContact.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Student updated successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            UploadPicture();
            LoadStudents();
        }

        private void btnChangePic_Click(object sender, EventArgs e)
        {
            UploadPicture();

            string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();

            MemoryStream ms = new MemoryStream();
            picStudent.Image.Save(ms, picStudent.Image.RawFormat);
            byte[] pic = ms.ToArray();

            string update_student_pic = "UPDATE `tbl_students` SET `picture`=@Pic WHERE `student_id`='" + selected_studentid + "';";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(update_student_pic, conn);

            cmd.Parameters.AddWithValue("@Pic", pic);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void UploadPicture()
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = new Bitmap(openfd.FileName);
                picStudent.ImageLocation = openfd.FileName;
                picStudent.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private Student CreateStudentModelFromForm()
        {
            return new Student()
            {
                StudentId = txtStudentId.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                SectionYear = txtSecYear.Text,
                CardId = txtRFID.Text,
                Contact = txtContact.Text,
                ParentContact = txtParentContact.Text
            };
        }

        private bool ValidateStudentModel(Student studentModel)
        {
            ValidationContext context = new ValidationContext(studentModel);
            IList<ValidationResult> errs = new List<ValidationResult>();

            return Validator.TryValidateObject(studentModel, context, errs, true);
        }

        private void DisplayValidationErrors(Student studentModel)
        {
            ValidationContext context = new ValidationContext(studentModel);
            IList<ValidationResult> errs = new List<ValidationResult>();
            Validator.TryValidateObject(studentModel, context, errs, true);

            StringBuilder errorMsg = new StringBuilder();
            foreach (ValidationResult res in errs)
                errorMsg.AppendLine(res.ErrorMessage);
            MessageBox.Show(errorMsg.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidatePictureBoxImage(PictureBox pictureBox)
        {
            return pictureBox.Image != null;
        }

        private bool IsStudentIdTaken(string studentId)
        {
            try
            {
                string query = "SELECT * FROM tbl_students WHERE student_id=@studentId";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        con.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool IsRFIDTaken(string rfid)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool IsRFIDTakenForUpdate(string rfid)
        {
            try
            {
                string query = "SELECT * FROM view_attendance_users WHERE card_id=@rfid and user_id!=@userid;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@rfid", rfid);
                        cmd.Parameters.AddWithValue("@userid", txtStudentId.Text);
                        con.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        DataTable dt = new DataTable();

        private async Task LoadStudents()
        {
            try
            {
                string loadStudentsQuery = "SELECT student_id, tbl_students.firstname, tbl_students.middlename, tbl_students.lastname, tbl_students.section_year, tbl_students.card_id,  tbl_students.contact, parent_contact, tbl_students.picture FROM tbl_students JOIN tbl_instructors ON tbl_students.section_year = tbl_instructors.advisory WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = @Username";

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
                    dgvStudentList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInfo()
        {
            string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();
            string selected_lastname = dgvStudentList.CurrentRow.Cells["lastname"].Value.ToString();
            string selected_firstname = dgvStudentList.CurrentRow.Cells["firstName"].Value.ToString();
            string selected_middlename = dgvStudentList.CurrentRow.Cells["middleName"].Value.ToString();
            string selected_secyear = dgvStudentList.CurrentRow.Cells["section_year"].Value.ToString();
            string selected_rfid = dgvStudentList.CurrentRow.Cells["card_id"].Value.ToString();
            string selected_contact = dgvStudentList.CurrentRow.Cells["contact"].Value.ToString();
            string selected_parentcontact = dgvStudentList.CurrentRow.Cells["parent_contact"].Value.ToString();

            DataGridViewImageCell imageCell = dgvStudentList.CurrentRow.Cells["picture"] as DataGridViewImageCell;

            if (imageCell.Value != null && imageCell.Value is byte[])
            {
                byte[] imageData = (byte[])imageCell.Value;
                
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image selected_image = Image.FromStream(ms);
                    picStudent.Image = selected_image;
                }
            }

            txtStudentId.Text = selected_studentid;
            txtFirstName.Text = selected_firstname;
            txtLastName.Text = selected_lastname;
            txtMiddleName.Text = selected_middlename;
            txtSecYear.Text = selected_secyear;
            txtRFID.Text = selected_rfid;
            txtContact.Text = selected_contact;
            txtParentContact.Text = selected_parentcontact;
        }

        private void ClearForm()
        {
            txtStudentId.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtRFID.Text = "";
            txtContact.Text = "";
            txtParentContact.Text = "";
            picStudent.Image = null;
            DefaultButtons();
            txtStudentId.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
            LoadStudents();
            ClearForm();
        }

        private void DeleteStudent()
        {
            if (MessageBox.Show("Are you sure you want to delete student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();

                string delete_row = "DELETE from tbl_students where student_id= '" + selected_studentid + "'";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(delete_row, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void HideButtons()
        {
            btnDelete.Enabled = true;
            btnUpdate.Visible = true;
            btnChangePic.Visible = true;
            btnAdd.Visible = false;
            btnUploadPic.Visible = false;
            txtStudentId.Enabled = false;
        }

        private void DefaultButtons()
        {
            btnDelete.Enabled = false;
            btnUpdate.Visible = false;
            btnChangePic.Visible = false;
            btnAdd.Visible = true;
            btnUploadPic.Visible = true;
            txtStudentId.Enabled = true;
        }

        private async void dgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowGraphs();
                ShowInfo();
                HideButtons();
            }
        }

        private async Task ShowGraphs()
        {
            string selected_studentid = dgvStudentList.CurrentRow.Cells["student_id"].Value.ToString();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // STUDENT PERCENTAGE
                    string classAttendanceQuery = "SELECT Total_Attendance, Total_Classes_Section FROM view_total_student_attendance " +
                                                  "JOIN view_total_section_attendance on view_total_student_attendance.Section = view_total_section_attendance.Section " +
                                                  "WHERE User_ID = @UserID;";
                    using (MySqlCommand command = new MySqlCommand(classAttendanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", selected_studentid);

                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            chartStudentPercentage.Series.Clear();
                            while (await reader.ReadAsync())
                            {
                                int totalStudentAttendance = Convert.ToInt32(reader["Total_Attendance"]);
                                int totalClassesConducted = Convert.ToInt32(reader["Total_Classes_Section"]);
                                double studentPercentage = ((double)totalStudentAttendance / totalClassesConducted) * 100;

                                Series series_totalstudents = chartStudentPercentage.Series.Add("StudentPercentage");
                                series_totalstudents.ChartType = SeriesChartType.Doughnut;
                                series_totalstudents.Points.Clear();
                                series_totalstudents.Points.AddY(100 - studentPercentage);
                                series_totalstudents.Points.AddY(studentPercentage);
                                series_totalstudents.Points[0].Label = "Absents: #VALY{0.00}%";
                                series_totalstudents.Points[0].Font = new Font("Arial", 12f);
                                series_totalstudents.Points[1].Label = "Presents: #VALY{0.00}%";
                                series_totalstudents.Points[1].Font = new Font("Arial", 14f);
                            }
                        }
                    }

                    // STUDENT ATTENDANCE PER CLASS
                    string studentAttendanceQuery = "SELECT view_total_conducted_classes.Schedule, Student_Attendance, Total_Conducted_Classes " +
                                                     "FROM view_total_conducted_classes " +
                                                     "JOIN view_student_attendance_perclass ON view_total_conducted_classes.Schedule = view_student_attendance_perclass.Schedule " +
                                                     "WHERE User_ID = @UserID;";
                    using (MySqlCommand command = new MySqlCommand(studentAttendanceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", selected_studentid);

                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            chartAttendancePerClass.Series[0].Points.Clear();

                            while (await reader.ReadAsync())
                            {
                                int studentAttendance = Convert.ToInt32(reader["Student_Attendance"]);
                                int totalConductedClasses = Convert.ToInt32(reader["Total_Conducted_Classes"]);
                                string classSchedule = reader["Schedule"].ToString();
                                double studentClassPercentage = ((double)studentAttendance / totalConductedClasses) * 100;

                                chartAttendancePerClass.Series[0].Points.AddXY(classSchedule, studentClassPercentage);
                                chartAttendancePerClass.ChartAreas[0].AxisY.Maximum = 100;
                                chartAttendancePerClass.ChartAreas[0].AxisY.LabelStyle.Format = "{0}%";
                                chartAttendancePerClass.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                chartAttendancePerClass.Series[0].Points.Clear();
                chartStudentPercentage.Series.Clear();
            }
        }

        private void btnViewStudentDetails_Click(object sender, EventArgs e)
        {
            PopStudentDetails dialog = new PopStudentDetails();
            dialog.ShowDialog();
        }

        private void btnViewSummary_Click(object sender, EventArgs e)
        {
            PopStudentSummary dialog = new PopStudentSummary();
            dialog.ShowDialog();
        }

        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("firstname LIKE '%{0}%' OR middlename LIKE '%{0}%' OR lastname LIKE '%{0}%'  OR student_id LIKE '%{0}%'", txtSearchStudent.Text);
        }
    }
}
