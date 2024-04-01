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
    public partial class FormAdminMain : Form
    {
        private Button activeButton;

        string connectionString = Database.connectionString;

        public FormAdminMain()
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

        private void FormAdminMain_Load(object sender, EventArgs e)
        {
            UC_AdminDashboard uc = new UC_AdminDashboard();
            addUserControl(uc);
            Button_Click(btnDashboard, EventArgs.Empty);
        }

        private void InitializeButtons()
        {
            btnDashboard.Click += Button_Click;
            btnStudents.Click += Button_Click;
            btnInstructors.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.MediumPurple;
                activeButton.ForeColor = Color.White;
            }

            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DarkOrchid;
            clickedButton.ForeColor = Color.White;
            activeButton = clickedButton;
        }

        private void addUserControl(UserControl UserControls)
        {
            UserControls.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(UserControls);
            UserControls.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UC_AdminDashboard uc = new UC_AdminDashboard();
            addUserControl(uc);
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            UC_AdminInstructors uc = new UC_AdminInstructors();
            addUserControl(uc);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            UC_AdminStudents uc = new UC_AdminStudents();
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

        private void FormAdminMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            PopAdminSettings dialog = new PopAdminSettings();
            dialog.ShowDialog();
        }

        private async void FormAdminMain_Shown(object sender, EventArgs e)
        {
            await PoolEvents();
        }
    }
}
