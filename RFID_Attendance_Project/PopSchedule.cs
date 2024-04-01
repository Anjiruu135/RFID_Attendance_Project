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
    public partial class PopSchedule : Form
    {
        string connectionString = Database.connectionString;

        public PopSchedule()
        {
            InitializeComponent();
            cmbDay.SelectedIndex = 0;
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

        private void btnAddSched_Click(object sender, EventArgs e)
        {
            var scheduleModel = CreateScheduleModelFromForm();
            string firstThreeLetters = cmbDay.Text.Substring(0, Math.Min(3, cmbDay.Text.Length));

            string SchedIdFormat = $"{txtSchedID.Text} - {cmbSection.Text} : {txtStartHr.Text}{txtStartMin.Text} - {txtEndHr.Text}{txtEndMin.Text} : {firstThreeLetters}";

            int startHour = int.Parse(txtStartHr.Text) * 60;
            int startMin = int.Parse(txtStartMin.Text);
            int endHour = int.Parse(txtEndHr.Text) * 60;
            int endMin = int.Parse(txtEndMin.Text);

            int start_time = startHour + startMin;
            int end_time = endHour + endMin;

            if (!ValidateStudentModel(scheduleModel))
            {
                DisplayValidationErrors(scheduleModel);
                return;
            }
            else if (start_time >= end_time)
            {
                MessageBox.Show("Start Time should start before End Time", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (IsScheduleIdTaken(SchedIdFormat))
                {
                    MessageBox.Show("Schedule ID / Schedule Time already taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (IsRoomScheduleTaken(cmbRoom.Text))
                {
                    MessageBox.Show("Room Shcedule Already Taken", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);

                    string get_instructor_forsubject = "SELECT tbl_instructors.* FROM tbl_instructors WHERE CONCAT(tbl_instructors.lastname, ', ', tbl_instructors.firstname) = '" + FormLogin.username_display + "'";
                    MySqlCommand forinstructor_commandDatabase = new MySqlCommand(get_instructor_forsubject, conn);
                    MySqlDataAdapter forinstructor_da = new MySqlDataAdapter(forinstructor_commandDatabase);

                    DataTable forinstructor_dt = new DataTable();
                    forinstructor_da.FillAsync(forinstructor_dt);
                    DataRow forinstructor_row = forinstructor_dt.Rows[0];

                    try
                    {
                        string add_schedule = "INSERT INTO `tbl_schedule`(`schedule_id`, `instructor_id`, `schedule_name`, `section_year`, `start_hour`, `start_minute`, `end_hour`, `end_minute`, `day`, `room`) VALUES (@SchedID,@InstructorID,@SchedDesc,@Section,@StartHr,@StartMin,@EndHr,@EndMin,@Day,@Room)";
                        MySqlCommand cmd = new MySqlCommand(add_schedule, conn);

                        cmd.Parameters.AddWithValue("@SchedID", SchedIdFormat);
                        cmd.Parameters.AddWithValue("@SchedDesc", txtSchedDesc.Text);
                        cmd.Parameters.AddWithValue("@InstructorID", forinstructor_row["instructor_id"]);
                        cmd.Parameters.AddWithValue("@Section", cmbSection.Text);
                        cmd.Parameters.AddWithValue("@StartHr", txtStartHr.Text);
                        cmd.Parameters.AddWithValue("@StartMin", txtStartMin.Text);
                        cmd.Parameters.AddWithValue("@EndHr", txtEndHr.Text);
                        cmd.Parameters.AddWithValue("@EndMin", txtEndMin.Text);
                        cmd.Parameters.AddWithValue("@Day", cmbDay.Text);
                        cmd.Parameters.AddWithValue("@Room", cmbRoom.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("New schedule added successfully", "Submit Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private async Task LoadSections(ComboBox comboBox)
        {
            string loadstudents_query = "SELECT advisory FROM tbl_instructors ORDER BY advisory ASC";
            DataTable dt = new DataTable();

            await Task.Run(() =>
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(loadstudents_query, conn))
                    {
                        da.Fill(dt);
                    }
                }
            });

            cmbSection.DataSource = null;
            cmbSection.DataSource = dt;
            cmbSection.DisplayMember = "advisory";
            cmbSection.ValueMember = "advisory";
        }

        private async Task LoadRooms(ComboBox comboBox)
        {
            string loadstudents_query = "SELECT * from tbl_rooms";
            DataTable dt = new DataTable();

            await Task.Run(() =>
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
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

        private async void PopSchedule_Load(object sender, EventArgs e)
        {
            await LoadSections(cmbSection);
            await LoadRooms(cmbRoom);
        }

        private void cmbInstructor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private Schedule CreateScheduleModelFromForm()
        {
            return new Schedule()
            {
                SchedID = txtSchedID.Text,
                SchedDesc = txtSchedDesc.Text,
                Section = cmbSection.Text,
                StartTimeHr = txtStartHr.Text,
                StartTimeMin = txtStartMin.Text,
                EndTimeHr = txtEndHr.Text,
                EndTimeMin = txtEndMin.Text,
                Day = cmbDay.Text,
                Room = cmbRoom.Text,
            };
        }

        private bool ValidateStudentModel(Schedule scheduleModel)
        {
            ValidationContext context = new ValidationContext(scheduleModel);
            IList<ValidationResult> errs = new List<ValidationResult>();

            return Validator.TryValidateObject(scheduleModel, context, errs, true);
        }

        private void DisplayValidationErrors(Schedule scheduleModel)
        {
            ValidationContext context = new ValidationContext(scheduleModel);
            IList<ValidationResult> errs = new List<ValidationResult>();
            Validator.TryValidateObject(scheduleModel, context, errs, true);

            StringBuilder errorMsg = new StringBuilder();
            foreach (ValidationResult res in errs)
                errorMsg.AppendLine(res.ErrorMessage);
            MessageBox.Show(errorMsg.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsScheduleIdTaken(string scheduleID)
        {
            string query = "SELECT * FROM tbl_schedule WHERE instructor_id = '" + FormLogin.instructorID_display + "' AND day = @Day AND ((CONVERT(start_hour, SIGNED) < @EndHour AND CONVERT(end_hour, SIGNED) > @StartHour) OR (start_hour = @StartHour AND CONVERT(start_minute, SIGNED) <= @StartMin AND end_hour = @EndHour AND CONVERT(end_minute, SIGNED) >= @EndMin)) OR schedule_id=@scheduleID";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@scheduleID", scheduleID);
                    cmd.Parameters.AddWithValue("@Day", cmbDay.Text);
                    cmd.Parameters.AddWithValue("@StartHour", int.Parse(txtStartHr.Text));
                    cmd.Parameters.AddWithValue("@EndHour", int.Parse(txtEndHr.Text));
                    cmd.Parameters.AddWithValue("@StartMin", int.Parse(txtStartMin.Text));
                    cmd.Parameters.AddWithValue("@EndMin", int.Parse(txtEndMin.Text));
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private bool IsRoomScheduleTaken(string room)
        {
            string query = "SELECT * FROM tbl_schedule WHERE day = @Day AND ((CONVERT(start_hour, SIGNED) < @EndHour AND CONVERT(end_hour, SIGNED) > @StartHour) OR (start_hour = @StartHour AND CONVERT(start_minute, SIGNED) <= @StartMin AND end_hour = @EndHour AND CONVERT(end_minute, SIGNED) >= @EndMin)) AND room = @Room;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Room", room);
                    cmd.Parameters.AddWithValue("@Day", cmbDay.Text);
                    cmd.Parameters.AddWithValue("@StartHour", int.Parse(txtStartHr.Text));
                    cmd.Parameters.AddWithValue("@EndHour", int.Parse(txtEndHr.Text));
                    cmd.Parameters.AddWithValue("@StartMin", int.Parse(txtStartMin.Text));
                    cmd.Parameters.AddWithValue("@EndMin", int.Parse(txtEndMin.Text));
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private void txtStartHr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtStartMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtEndhr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtEndMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void cmbDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
