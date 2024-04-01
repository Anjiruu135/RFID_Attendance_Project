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

namespace RFID_Attendance_Project.UserControls
{
    public partial class UC_AdminDashboard : UserControl
    {
        string connectionString = Database.connectionString;

        public UC_AdminDashboard()
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

        private async void UC_AdminDashboard_Load(object sender, EventArgs e)
        {
            await LoadDepartments();
            await LoadRooms();
            picEvents.SizeMode = PictureBoxSizeMode.StretchImage;
            StartCarousel();
            lblDate.Text = DateTime.Now.ToLongDateString();
            await ShowDashboardInfo();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer.Start();
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            PopDepartment dialog = new PopDepartment();
            dialog.ShowDialog();
            LoadDepartments();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            PopRoom dialog = new PopRoom();
            dialog.ShowDialog();
            LoadRooms();
        }

        private async Task LoadDepartments()
        {
            try
            {
                string loaddepartments_query = "SELECT * from tbl_departments";
                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(loaddepartments_query, conn))
                    {
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    dgvDepartments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task LoadRooms()
        {
            try
            {
                string loadrooms_query = "SELECT * from tbl_rooms";
                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (MySqlCommand cmd = new MySqlCommand(loadrooms_query, conn))
                    {
                        using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                    dgvRooms.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private DataTable imageDataTable;
        private int currentIndex = 0;

        private void StartCarousel()
        {
            imageDataTable = FetchImageDataFromJson();
            DisplayCurrentImage();

            timerCarousel.Interval = 6000;
            timerCarousel.Tick += timerCarousel_Tick;
            timerCarousel.Start();
        }

        private void timerCarousel_Tick(object sender, EventArgs e)
        {
            if (imageDataTable.Rows.Count > 0)
            {
                currentIndex = (currentIndex + 1) % imageDataTable.Rows.Count;
                DisplayCurrentImage();
            }
            else
            {
                currentIndex = 0;
            }
        }


        private DataTable FetchImageDataFromJson()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string jsonFilePath = "eventpics.json";
                string jsonData = File.ReadAllText(jsonFilePath);
                dataTable = JsonConvert.DeserializeObject<DataTable>(jsonData);
            }
            catch (Exception ex)
            {
                
            }

            return dataTable;
        }

        private void DisplayCurrentImage()
        {
            try
            {
                if (imageDataTable != null && imageDataTable.Rows.Count > 0)
                {
                    string base64ImageData = imageDataTable.Rows[currentIndex]["event_pic"].ToString();
                    byte[] imageData = Convert.FromBase64String(base64ImageData);
                    picEvents.Image = Image.FromStream(new MemoryStream(imageData));
                }
                else
                {
                    picEvents.Image = null;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                picEvents.Image = new Bitmap(openfd.FileName);
                picEvents.ImageLocation = openfd.FileName;
                picEvents.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            MemoryStream ms = new MemoryStream();
            picEvents.Image.Save(ms, picEvents.Image.RawFormat);
            byte[] pic = ms.ToArray();

            string update_student_pic = "INSERT INTO tbl_events(event_pic) VALUES (@Pic);";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(update_student_pic, conn);

            cmd.Parameters.AddWithValue("@Pic", pic);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private async Task ShowDashboardInfo()
        {
            try
            {
                // STUDENTS INSIDE CAMPUS COUNT
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string countQuery = $@"
                        SELECT COUNT(DISTINCT fullname) as students_inside
                        FROM tbl_schoolattendance
                        JOIN view_attendance_users ON tbl_schoolattendance.user_id = view_attendance_users.user_id
                        WHERE user_type='student' AND time_out='' AND date='{DateTime.Now.ToLongDateString()}';
                    ";

                    using (MySqlCommand command = new MySqlCommand(countQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable CountTable = new DataTable();
                            CountTable.Load(reader);
                            if (CountTable.Rows.Count > 0)
                            {
                                lblNoStudents.Text = CountTable.Rows[0]["students_inside"].ToString();
                            }
                            else
                            {
                                lblNoStudents.Text = "0";
                            }
                        }
                    }
                }

                // INSTRUCTORS INSIDE CAMPUS COUNT
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string countQuery = $@"
                        SELECT COUNT(DISTINCT fullname) as instructor_inside
                        FROM tbl_schoolattendance
                        JOIN view_attendance_users ON tbl_schoolattendance.user_id = view_attendance_users.user_id
                        WHERE user_type='instructor' AND time_out='' AND date='{DateTime.Now.ToLongDateString()}';
                    ";

                    using (MySqlCommand command = new MySqlCommand(countQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable CountTable = new DataTable();
                            CountTable.Load(reader);
                            if (CountTable.Rows.Count > 0)
                            {
                                lblNoInstructors.Text = CountTable.Rows[0]["instructor_inside"].ToString();
                            }
                            else
                            {
                                lblNoInstructors.Text = "0";
                            }
                        }
                    }
                }

                // ENROLLED STUDENTS COUNT
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string countQuery = $@"
                        SELECT COUNT(DISTINCT user_id) as enrolled_students FROM view_attendance_users WHERE user_type='student';
                    ";

                    using (MySqlCommand command = new MySqlCommand(countQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable CountTable = new DataTable();
                            CountTable.Load(reader);
                            if (CountTable.Rows.Count > 0)
                            {
                                lblEnrolledStudents.Text = CountTable.Rows[0]["enrolled_students"].ToString();
                            }
                            else
                            {
                                lblEnrolledStudents.Text = "0";
                            }
                        }
                    }
                }

                // REGISTERED INSTRUCTORS COUNT
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string countQuery = $@"
                        SELECT COUNT(DISTINCT user_id) as registered_instructor FROM view_attendance_users WHERE user_type='instructor';
                    ";

                    using (MySqlCommand command = new MySqlCommand(countQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable CountTable = new DataTable();
                            CountTable.Load(reader);
                            if (CountTable.Rows.Count > 0)
                            {
                                lblRegisteredInstructors.Text = CountTable.Rows[0]["registered_instructor"].ToString();
                            }
                            else
                            {
                                lblRegisteredInstructors.Text = "0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnEventList_Click(object sender, EventArgs e)
        {
            PopEventList dialog = new PopEventList();
            dialog.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete department?", "Delete Department", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selected_department = dgvDepartments.CurrentRow.Cells["department"].Value.ToString();

                string delete_row = "DELETE from tbl_departments where department= '" + selected_department + "'";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(delete_row, conn);

                btnDelete.Enabled = false;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadDepartments();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete room?", "Delete Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selected_room = dgvRooms.CurrentRow.Cells["room"].Value.ToString();

                string delete_row = "DELETE from tbl_rooms where room= '" + selected_room + "'";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(delete_row, conn);

                btnDeleteRoom.Enabled = false;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            LoadRooms();
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDelete.Enabled = true;
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDeleteRoom.Enabled = true;
            }
        }
    }
}
