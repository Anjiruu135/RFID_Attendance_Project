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
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project
{
    public partial class PopRoom : Form
    {
        string connectionString = Database.connectionString;

        public PopRoom()
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

        private Room CreateRoomModelFromForm()
        {
            return new Room()
            {
                Room_ID = txtRoom.Text,
            };
        }

        private bool ValidateRoomModel(Room roomModel)
        {
            ValidationContext context = new ValidationContext(roomModel);
            IList<ValidationResult> errs = new List<ValidationResult>();

            return Validator.TryValidateObject(roomModel, context, errs, true);
        }

        private void DisplayValidationErrors(Room roomModel)
        {
            ValidationContext context = new ValidationContext(roomModel);
            IList<ValidationResult> errs = new List<ValidationResult>();
            Validator.TryValidateObject(roomModel, context, errs, true);

            StringBuilder errorMsg = new StringBuilder();
            foreach (ValidationResult res in errs)
                errorMsg.AppendLine(res.ErrorMessage);
            MessageBox.Show(errorMsg.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsDepartmentIdTaken(string RoomID)
        {
            string query = "SELECT * FROM tbl_rooms WHERE room=@RoomID";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var roomModel = CreateRoomModelFromForm();

            if (!ValidateRoomModel(roomModel))
            {
                DisplayValidationErrors(roomModel);
                return;
            }
            else
            {
                if (IsDepartmentIdTaken(txtRoom.Text))
                {
                    MessageBox.Show("Room already added", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    try
                    {
                        string add_department = "INSERT INTO tbl_rooms (room) VALUES (@RoomID)";
                        MySqlCommand cmd = new MySqlCommand(add_department, conn);

                        cmd.Parameters.AddWithValue("@RoomID", txtRoom.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("New Room added successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
