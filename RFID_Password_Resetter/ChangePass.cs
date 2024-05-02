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

namespace RFID_Password_Resetter
{
    public partial class ChangePass : Form
    {
        public static string connectionString = "server=bxu5ubp632mm3zdxq3pn-mysql.services.clever-cloud.com; username=u2d5sqrzrbfmdj8i; password=a5v5SamFQ4Ic3aLL6OqJ; database=bxu5ubp632mm3zdxq3pn; port=3306; ";

        public ChangePass()
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset the password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string change_password = "UPDATE tbl_users SET `password`=@NewPassword WHERE user_id = 'admin';";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(change_password, conn);

                cmd.Parameters.AddWithValue("@NewPassword", Encrypt.HashString(txtPassword.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Password Changed Successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
