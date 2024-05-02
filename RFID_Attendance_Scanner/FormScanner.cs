using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace RFID_Attendance_Scanner
{
    public partial class FormScanner : Form
    {
        public static string connectionString = "server=bxu5ubp632mm3zdxq3pn-mysql.services.clever-cloud.com; username=u2d5sqrzrbfmdj8i; password=a5v5SamFQ4Ic3aLL6OqJ; database=bxu5ubp632mm3zdxq3pn; port=3306; ";

        public FormScanner()
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

        private void ScanID()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            if (IsRFIDValid(txtIDBox.Text))
            {
                string Scanned_ID = txtIDBox.Text;
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

                foreach (var student in students)
                {
                    if (student.card_id == Scanned_ID)
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

                if (IsUserTimedIn(taken_id))
                {

                    string update_attendance = "UPDATE `tbl_schoolattendance` SET `time_out`=@Time WHERE user_id=@ID";

                    MySqlCommand cmd = new MySqlCommand(update_attendance, conn);

                    cmd.Parameters.AddWithValue("@ID", row["user_id"]);
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblStatus.Text = "Time Out";
                    lblStatus.BackColor = Color.FromArgb(255, 128, 128);
                }
                else if (IsUserTimedInAndTimedOut(taken_id))
                {

                    string add_attendance = "INSERT INTO `tbl_schoolattendance`(`user_id`, `fullname`, `date`, `time_in`, `time_out`) VALUES (@ID,@Fullname,@Date,@Time,' ')";

                    MySqlCommand cmd = new MySqlCommand(add_attendance, conn);

                    cmd.Parameters.AddWithValue("@ID", row["user_id"]);
                    cmd.Parameters.AddWithValue("@Fullname", row["lastname"] + ", " + row["firstname"]);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblStatus.Text = "Time In";
                    lblStatus.BackColor = Color.FromArgb(128, 255, 128);
                }
                else
                {
                    string add_attendance = "INSERT INTO `tbl_schoolattendance`(`user_id`, `fullname`, `date`, `time_in`, `time_out`) VALUES (@ID,@Fullname,@Date,@Time,' ')";

                    MySqlCommand cmd = new MySqlCommand(add_attendance, conn);

                    cmd.Parameters.AddWithValue("@ID", row["user_id"]);
                    cmd.Parameters.AddWithValue("@Fullname", row["lastname"] + ", " + row["firstname"]);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblStatus.Text = "Time In";
                    lblStatus.BackColor = Color.FromArgb(128, 255, 128);
                }

                lblName.Text = row["lastname"] + ", " + row["firstname"];
                lblTime.Text = DateTime.Now.ToLongTimeString();

                byte[] pic = (byte[])row["picture"];
                MemoryStream ms = new MemoryStream(pic);
                picBox.Image = Image.FromStream(ms);
            }
            else
            {
                lblStatus.Text = "Invalid";
                lblStatus.BackColor = Color.Black;
                lblStatus.ForeColor = Color.White;
                lblName.Text = "Name";
                lblTime.Text = "Time";
                picBox.Image = null;
            }
        }

        private bool IsRFIDValid(string rfid)
        {
            string Scanned_ID = txtIDBox.Text;
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

            foreach (var student in students)
            {
                if (student.card_id == Scanned_ID)
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

            return dt.Rows.Count > 0;
        }

        private bool IsUserTimedIn(string user_id)
        {
            string query = "SELECT * FROM tbl_schoolattendance WHERE date=@Date AND time_in IS NOT NULL AND time_out=' ' AND user_id=@UserID";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", user_id);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private bool IsUserTimedInAndTimedOut(string user_id)
        {
            string query = "SELECT * FROM tbl_schoolattendance WHERE date=@Date AND time_in IS NOT NULL AND time_out IS NOT NULL AND user_id=@UserID";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", user_id);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void txtIDBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ScanID();
                txtIDBox.Clear();
            }
        }

        private async Task PoolUsers()
        {
            string query = "SELECT * FROM view_attendance_users";

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
                                    if (reader.GetFieldType(i) == typeof(byte[]))
                                    {
                                        row[reader.GetName(i)] = Convert.ToBase64String((byte[])reader[i]);
                                    }
                                    else
                                    {
                                        row[reader.GetName(i)] = reader[i].ToString();
                                    }
                                }
                                resultSet.Add(row);
                            }
                            string json = JsonConvert.SerializeObject(resultSet);
                            File.WriteAllText("users.json", json);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FormScanner_Shown(object sender, EventArgs e)
        {
            await PoolUsers();
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
    }
}
