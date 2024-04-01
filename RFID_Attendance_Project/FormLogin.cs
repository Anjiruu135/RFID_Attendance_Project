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
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project
{
    public partial class FormLogin : Form
    {
        string connectionString = Database.connectionString;

        public static string username_display;
        public static string advisory_display;
        public static string instructorID_display;

        public FormLogin()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);

                string user_query = "SELECT tbl_users.*, tbl_instructors.advisory FROM tbl_users JOIN tbl_instructors on tbl_users.user_id = tbl_instructors.instructor_id Where user_id='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "' AND user_type='user';";
                MySqlCommand cmd_user = new MySqlCommand(user_query, conn);

                string admin_query = "SELECT * FROM tbl_users Where user_id='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "' AND user_type='admin'";
                MySqlCommand cmd_admin = new MySqlCommand(admin_query, conn);

                MySqlDataReader reader_user;
                MySqlDataReader reader_admin;

                conn.Open();
                reader_user = cmd_user.ExecuteReader();
                if (reader_user.HasRows)
                {
                    while (reader_user.Read())
                    {
                        MessageBox.Show("Successful Login", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string username = reader_user["name"].ToString();
                        string advisory = reader_user["advisory"].ToString();
                        string instructor_id = reader_user["user_id"].ToString();
                        username_display = username;
                        advisory_display = advisory;
                        instructorID_display = instructor_id;

                        this.Hide();
                        FormUserMain form = new FormUserMain();
                        form.Show();
                    }
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    reader_admin = cmd_admin.ExecuteReader();

                    if (reader_admin.HasRows)
                    {
                        while (reader_admin.Read())
                        {
                            MessageBox.Show("Successful Login", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FormAdminMain form = new FormAdminMain();
                            form.Show();
                        }
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username/Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
