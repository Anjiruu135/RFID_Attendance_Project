using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Attendance_Project.UserControls;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.IO;

namespace RFID_Attendance_Project
{
    public partial class FormUserMain : Form
    {
        private Button activeButton;

        string connectionString = Database.connectionString;

        public FormUserMain()
        {
            InitializeComponent();
            InitializeButtons();
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

        private void FormUserMain_Load(object sender, EventArgs e)
        {
            lblInstructorName.Text = FormLogin.username_display;
            Button_Click(btnDashboard, EventArgs.Empty);
            btnDashboard_Click(null, EventArgs.Empty);
        }

        private void InitializeButtons()
        {
            btnDashboard.Click += Button_Click;
            btnStudents.Click += Button_Click;
            btnAttendance.Click += Button_Click;
            btnInstructors.Click += Button_Click;
            btnScanner.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.RoyalBlue;
                activeButton.ForeColor = Color.White;
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DodgerBlue;
            clickedButton.ForeColor = Color.White;
            activeButton = clickedButton;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UC_UserDashboard uc = new UC_UserDashboard();
            addUserControl(uc);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            UC_UserStudents uc = new UC_UserStudents();
            addUserControl(uc);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            UC_UserAttendance uc = new UC_UserAttendance();
            addUserControl(uc);
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            UC_UserInstructor uc = new UC_UserInstructor();
            addUserControl(uc);
        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            UC_UserScanner uc = new UC_UserScanner();
            addUserControl(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormLogin form = new FormLogin();
                form.Show();
            }
        }

        private void FormUserMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async Task PoolSchedule()
        {
            string query = "SELECT tbl_schedule.* FROM tbl_schedule JOIN tbl_instructors on tbl_schedule.instructor_id = tbl_instructors.instructor_id WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '" + FormLogin.username_display + "' ORDER BY start_hour ASC, start_minute ASC";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            List<Dictionary<string, string>> resultSet = new List<Dictionary<string, string>>();
                            while (reader.Read())
                            {
                                Dictionary<string, string> row = new Dictionary<string, string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader[i].ToString();
                                }
                                resultSet.Add(row);
                            }
                            string json = JsonConvert.SerializeObject(resultSet);
                            File.WriteAllText("schedule.json", json);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PoolStudents()
        {
            string query = "SELECT view_attendance_users.* FROM view_attendance_users WHERE user_type='student'";
            int batchSize = 1000;
            int offset = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    List<Dictionary<string, string>> resultSet = new List<Dictionary<string, string>>();
                    while (true)
                    {
                        string batchQuery = $"{query} LIMIT {offset},{batchSize}";
                        using (MySqlCommand command = new MySqlCommand(batchQuery, connection))
                        using (var reader = await Task.Run(() => command.ExecuteReader()))
                        {
                            if (!reader.HasRows)
                                break;

                            while (await reader.ReadAsync())
                            {
                                Dictionary<string, string> row = new Dictionary<string, string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.IsDBNull(i))
                                        row[reader.GetName(i)] = null;
                                    else if (reader.GetFieldType(i) == typeof(byte[]))
                                        row[reader.GetName(i)] = Convert.ToBase64String((byte[])reader[i]);
                                    else
                                        row[reader.GetName(i)] = reader[i].ToString();
                                }
                                resultSet.Add(row);
                            }
                        }
                        offset += batchSize;
                    }

                    using (StreamWriter writer = new StreamWriter("localusers.json"))
                    using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jsonWriter, resultSet);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PoolInstructors()
        {
            string query = "SELECT view_attendance_users.*, tbl_schedule.schedule_id FROM view_attendance_users JOIN tbl_schedule on view_attendance_users.user_id = tbl_schedule.instructor_id WHERE user_type='instructor'";
            int batchSize = 1000;
            int offset = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    List<Dictionary<string, string>> resultSet = new List<Dictionary<string, string>>();
                    while (true)
                    {
                        string batchQuery = $"{query} LIMIT {offset},{batchSize}";
                        using (MySqlCommand command = new MySqlCommand(batchQuery, connection))
                        using (var reader = await Task.Run(() => command.ExecuteReader()))
                        {
                            if (!reader.HasRows)
                                break;

                            while (await reader.ReadAsync())
                            {
                                Dictionary<string, string> row = new Dictionary<string, string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.IsDBNull(i))
                                        row[reader.GetName(i)] = null;
                                    else if (reader.GetFieldType(i) == typeof(byte[]))
                                        row[reader.GetName(i)] = Convert.ToBase64String((byte[])reader[i]);
                                    else
                                        row[reader.GetName(i)] = reader[i].ToString();
                                }
                                resultSet.Add(row);
                            }
                        }
                        offset += batchSize;
                    }

                    using (StreamWriter writer = new StreamWriter("instructors.json"))
                    using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jsonWriter, resultSet);
                    }
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PoolEvents()
        {
            string query = "SELECT event_pic FROM tbl_events";
            int batchSize = 1000;
            int offset = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    List<Dictionary<string, string>> resultSet = new List<Dictionary<string, string>>();
                    while (true)
                    {
                        string batchQuery = $"{query} LIMIT {offset},{batchSize}";
                        using (MySqlCommand command = new MySqlCommand(batchQuery, connection))
                        using (var reader = await Task.Run(() => command.ExecuteReader()))
                        {
                            if (!reader.HasRows)
                                break;

                            while (await reader.ReadAsync())
                            {
                                Dictionary<string, string> row = new Dictionary<string, string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.IsDBNull(i))
                                        row[reader.GetName(i)] = null;
                                    else if (reader.GetFieldType(i) == typeof(byte[]))
                                        row[reader.GetName(i)] = Convert.ToBase64String((byte[])reader[i]);
                                    else
                                        row[reader.GetName(i)] = reader[i].ToString();
                                }
                                resultSet.Add(row);
                            }
                        }
                        offset += batchSize;
                    }

                    using (StreamWriter writer = new StreamWriter("eventpics.json"))
                    using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jsonWriter, resultSet);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FormUserMain_Shown(object sender, EventArgs e)
        {
            await PoolSchedule();
            await PoolStudents();
            await PoolInstructors();
            await PoolEvents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Invalidate(true);
            this.Update();
            PoolSchedule();
            PoolStudents();
            PoolInstructors();
            PoolEvents();
            MessageBox.Show("Data reload successful!", "Reload Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
