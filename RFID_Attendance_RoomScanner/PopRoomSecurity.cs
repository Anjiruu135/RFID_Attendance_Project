using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_RoomScanner
{
    public partial class PopRoomSecurity : Form
    {
        public static string connectionString = "server=bxu5ubp632mm3zdxq3pn-mysql.services.clever-cloud.com; username=u2d5sqrzrbfmdj8i; password=a5v5SamFQ4Ic3aLL6OqJ; database=bxu5ubp632mm3zdxq3pn; port=3306; ";

        public PopRoomSecurity()
        {
            InitializeComponent();
        }

        private bool IsCurrentPasswordCorrect(string password)
        {
            string query = "SELECT * from tbl_users WHERE user_id='admin' and password=@Password";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Password", Encrypt.HashString(password));
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (IsCurrentPasswordCorrect(txtPassword.Text))
            {
                MessageBox.Show("Correct Password", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopSelectRoom dialog = new PopSelectRoom();
                dialog.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
