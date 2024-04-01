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
    public partial class PopSelectRoom : Form
    {
        public PopSelectRoom()
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

        private async Task LoadRooms(ComboBox comboBox)
        {
            string loadstudents_query = "SELECT * from tbl_rooms";
            DataTable dt = new DataTable();

            await Task.Run(() =>
            {
                using (MySqlConnection conn = new MySqlConnection(FormRoomScanner.connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(loadstudents_query, conn))
                    {
                        da.Fill(dt);
                    }
                }
            });

            cmbRoom.DataSource = null;
            cmbRoom.DataSource = dt;
            cmbRoom.DisplayMember = "room";
            cmbRoom.ValueMember = "room";
        }

        private async void PopSelectRoom_Load(object sender, EventArgs e)
        {
            await LoadRooms(cmbRoom);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            FormRoomScanner.selected_room = cmbRoom.Text;
            Properties.Settings.Default.Room = FormRoomScanner.selected_room;
            Properties.Settings.Default.Save();
            MessageBox.Show("Room selected successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
