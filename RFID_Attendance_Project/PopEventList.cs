using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace RFID_Attendance_Project
{
    public partial class PopEventList : Form
    {
        string connectionString = Database.connectionString;

        public PopEventList()
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

        private async void PopEventList_Load(object sender, EventArgs e)
        {
             await LoadEvents();
        }

        private async Task LoadEvents()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string EventQuery = "SELECT id, event_pic FROM tbl_events;";

                    using (MySqlCommand command = new MySqlCommand(EventQuery, connection))
                    {
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int id = (int)reader["id"];
                                byte[] imageData = (byte[])reader["event_pic"];
                                Image image = Image.FromStream(new MemoryStream(imageData));

                                int imageColumnIndex = dgvEvents.Columns["event_pic"].Index;
                                int idColumnIndex = dgvEvents.Columns["id"].Index;

                                dgvEvents.Rows.Add();
                                dgvEvents.Rows[dgvEvents.Rows.Count - 1].Cells[imageColumnIndex].Value = image;
                                dgvEvents.Rows[dgvEvents.Rows.Count - 1].Cells[idColumnIndex].Value = id;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete event?", "Delete Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selected_event = dgvEvents.CurrentRow.Cells["id"].Value.ToString();

                string delete_row = "DELETE from tbl_events where id= '" + selected_event + "'";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(delete_row, conn);

                btnDelete.Enabled = false;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            dgvEvents.Rows.Clear();
            LoadEvents();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDelete.Enabled = true;
            }
        }
    }
}
