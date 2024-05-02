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
using System.Net;
using System.Net.Mail;

namespace RFID_Attendance_RoomScanner
{
    public partial class FormRoomScanner : Form
    {
        public static string connectionString = "server=bxu5ubp632mm3zdxq3pn-mysql.services.clever-cloud.com; username=u2d5sqrzrbfmdj8i; password=a5v5SamFQ4Ic3aLL6OqJ; database=bxu5ubp632mm3zdxq3pn; port=3306; ";
        public static string selected_room;

        public FormRoomScanner()
        {
            InitializeComponent();
            TimerSubject.Interval = 5000;
            TimerSubject.Tick += SubjectTimer_Tick;
            TimerSubject.Start();
            txtIDBox.Focus();
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

        private void btnSelectRoom_Click(object sender, EventArgs e)
        {
            PopRoomSecurity dialog = new PopRoomSecurity();
            dialog.ShowDialog();
            lblRoom.Text = selected_room;
        }

        private void FormRoomScanner_Load(object sender, EventArgs e)
        {
            selected_room = Properties.Settings.Default.Room;
            lblRoom.Text = selected_room;
            txtIDBox.Focus();
            StartCarousel();
        }

        public class JSONStudent
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

        private async void ScanID()
        {
            string Scanned_ID = txtIDBox.Text;
            using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
            {
                var jsonData = File.ReadAllText("localusers.json");
                var students = JsonConvert.DeserializeObject<List<JSONStudent>>(jsonData);

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
                    if (student.card_id == Scanned_ID && student.section == lblSection.Text)
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

                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        string add_attendance = "INSERT INTO `tbl_classattendance`(`user_id`, `section_year`, `schedule_id`, `fullname`, `date`, `time_in`) VALUES (@ID,@Section,@ScheduleID,@Fullname,@Date,@Time)";

                        await databaseConnection.OpenAsync();
                        MySqlCommand cmd = new MySqlCommand(add_attendance, databaseConnection);
                        cmd.Parameters.AddWithValue("@ID", row["user_id"]);
                        cmd.Parameters.AddWithValue("@Fullname", row["lastname"] + ", " + row["firstname"]);
                        cmd.Parameters.AddWithValue("@Section", row["section"]);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                        cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString());
                        cmd.Parameters.AddWithValue("@ScheduleID", lblSchedID.Text);

                        await cmd.ExecuteNonQueryAsync();

                        lblName.Invoke((MethodInvoker)(() => { lblName.Text = row["lastname"] + ", " + row["firstname"]; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.Text = "Time In"; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.BackColor = Color.FromArgb(128, 255, 128); }));
                        lblTime.Invoke((MethodInvoker)(() => { lblTime.Text = DateTime.Now.ToString("t"); }));

                        byte[] pic = (byte[])row["picture"];
                        using (MemoryStream ms = new MemoryStream(pic))
                        {
                            picBox.Invoke((MethodInvoker)(() => { picBox.Image = Image.FromStream(ms); }));
                        }
                    }
                    else
                    {
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.Text = "Invalid"; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.BackColor = Color.Black; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.ForeColor = Color.White; }));
                        lblName.Invoke((MethodInvoker)(() => { lblName.Text = "Name"; }));
                        lblTime.Invoke((MethodInvoker)(() => { lblTime.Text = "Time"; }));
                        picBox.Invoke((MethodInvoker)(() => { picBox.Image = null; }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.ToString()}");
                }
            }
        }

        public class JSONInstructor
        {
            public string user_id { get; set; }
            public string user_type { get; set; }
            public string firstname { get; set; }
            public string middlename { get; set; }
            public string lastname { get; set; }
            public string card_id { get; set; }
            public string section { get; set; }
            public byte[] picture { get; set; }
            public string schedule_id { get; set; }
        }

        bool InstructorHasTimedIn = false;
        bool isScheduleActive = false;
        int schedEnd_hour, schedEnd_minute;
        string currentSchedID, messageSchedID, currentSection;

        private async void ScanInstructorID()
        {
            string Scanned_ID = txtInstructorIDBox.Text;
            using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
            {
                var jsonData = File.ReadAllText("instructors.json");
                var instructors = JsonConvert.DeserializeObject<List<JSONInstructor>>(jsonData);

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
                    new DataColumn("schedule_id", typeof(string)),
                });

                foreach (var instructor in instructors)
                {
                    if (instructor.card_id == Scanned_ID && instructor.schedule_id == lblSchedID.Text)
                    {
                        dt.Rows.Add(
                            instructor.user_id,
                            instructor.user_type,
                            instructor.firstname,
                            instructor.middlename,
                            instructor.lastname,
                            instructor.card_id,
                            instructor.section,
                            instructor.picture,
                            instructor.schedule_id
                        );
                    }
                }

                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        string add_attendance = "INSERT INTO `tbl_classattendance`(`user_id`, `section_year`, `schedule_id`, `fullname`, `date`, `time_in`) VALUES (@ID,@Section,@ScheduleID,@Fullname,@Date,@Time)";

                        await databaseConnection.OpenAsync();
                        MySqlCommand cmd = new MySqlCommand(add_attendance, databaseConnection);
                        cmd.Parameters.AddWithValue("@ID", row["user_id"]);
                        cmd.Parameters.AddWithValue("@Fullname", row["lastname"] + ", " + row["firstname"]);
                        cmd.Parameters.AddWithValue("@Section", row["section"]);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                        cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToLongTimeString());
                        cmd.Parameters.AddWithValue("@ScheduleID", lblSchedID.Text);

                        await cmd.ExecuteNonQueryAsync();

                        lblName.Invoke((MethodInvoker)(() => { lblName.Text = row["lastname"] + ", " + row["firstname"]; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.Text = "Time In"; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.BackColor = Color.FromArgb(128, 255, 128); }));
                        lblTime.Invoke((MethodInvoker)(() => { lblTime.Text = DateTime.Now.ToString("t"); }));

                        byte[] pic = (byte[])row["picture"];
                        using (MemoryStream ms = new MemoryStream(pic))
                        {
                            picBox.Invoke((MethodInvoker)(() => { picBox.Image = Image.FromStream(ms); }));
                        }

                        txtIDBox.Enabled = true;
                        txtIDBox.Visible = true;
                        txtInstructorIDBox.Enabled = false;
                        txtInstructorIDBox.Visible = false;
                        InstructorHasTimedIn = true;
                    }
                    else
                    {
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.Text = "Invalid"; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.BackColor = Color.Black; }));
                        lblStatus.Invoke((MethodInvoker)(() => { lblStatus.ForeColor = Color.White; }));
                        lblName.Invoke((MethodInvoker)(() => { lblName.Text = "Name"; }));
                        lblTime.Invoke((MethodInvoker)(() => { lblTime.Text = "Time"; }));
                        picBox.Invoke((MethodInvoker)(() => { picBox.Image = null; }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.ToString()}");
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

        private void txtInstructorIDBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ScanInstructorID();
                txtInstructorIDBox.Clear();
            }
        }

        public class Schedule
        {
            public string schedule_id { get; set; }
            public string schedule_name { get; set; }
            public string section_year { get; set; }
            public int start_hour { get; set; }
            public int start_minute { get; set; }
            public int end_hour { get; set; }
            public int end_minute { get; set; }
            public string day { get; set; }
        }

        private bool emailSent = false;
        private bool emailSendingInProgress = false;

        private async void SubjectTimer_Tick(object sender, EventArgs e)
        {
            string schedulejson = File.ReadAllText("schedule.json");
            List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(schedulejson);

            DateTime currentTime = DateTime.Now;

            if (!isScheduleActive)
            {
                foreach (var schedule in schedules)
                {
                    if (schedule.day.Equals(currentTime.DayOfWeek.ToString(), StringComparison.InvariantCultureIgnoreCase) && currentTime.TimeOfDay > new TimeSpan(schedule.start_hour, schedule.start_minute, 0) && currentTime.TimeOfDay < new TimeSpan(schedule.end_hour, schedule.end_minute, 0))
                    {
                        this.Focus();
                        txtInstructorIDBox.Enabled = true;
                        txtInstructorIDBox.Visible = true;
                        txtInstructorIDBox.Focus();
                        lblSubject.Text = schedule.schedule_name;
                        lblSchedID.Text = schedule.schedule_id;
                        lblSection.Text = schedule.section_year;
                        schedEnd_hour = schedule.end_hour;
                        schedEnd_minute = schedule.end_minute;
                        currentSchedID = schedule.schedule_id;
                        currentSection = schedule.section_year;
                        isScheduleActive = true;
                        emailSent = false;
                        break;
                    }
                    else
                    {
                        txtIDBox.Enabled = false;
                        txtIDBox.Visible = false;
                        txtInstructorIDBox.Enabled = false;
                        txtInstructorIDBox.Visible = true;
                        lblSubject.Text = "No Schedule at This Time...";
                        lblSchedID.Text = "Sched ID";
                        lblSection.Text = "Section";
                        picBox.Image = null;
                        lblName.Text = "Name";
                        lblStatus.Text = "Status";
                        lblStatus.BackColor = SystemColors.Control;
                        lblTime.Text = "Time";
                    }
                }
            }

            if (isScheduleActive && !emailSent && !emailSendingInProgress)
            {
                if (currentTime.TimeOfDay > new TimeSpan(schedEnd_hour, schedEnd_minute, 0))
                {
                    emailSendingInProgress = true;
                    messageSchedID = currentSchedID;

                    if (InstructorHasTimedIn)
                    {
                        await SendMessageAsync();
                    }
                    else
                    {
                        await SendMessageInstructorAsync();
                    }
                    isScheduleActive = false;
                    emailSendingInProgress = false;
                    emailSent = true;
                    InstructorHasTimedIn = false;
                }
            }
        }


        private async Task SendMessageAsync()
        {
            string loadAbsentQuery = "SELECT tbl_students.* FROM tbl_students LEFT JOIN tbl_classattendance ON tbl_students.student_id = tbl_classattendance.user_id AND tbl_classattendance.schedule_id = @messageSchedID AND tbl_classattendance.date = @Date WHERE tbl_classattendance.user_id IS NULL AND tbl_students.section_year = '" + currentSection + "' GROUP BY tbl_students.student_id";

            string getSchedID = lblSchedID.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(loadAbsentQuery, conn))
                {
                    command.Parameters.AddWithValue("@messageSchedID", getSchedID);
                    command.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());

                    await conn.OpenAsync();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                string studentName = reader["lastname"].ToString() + ", " + reader["firstname"].ToString() + " " + reader["middlename"].ToString();
                                string section = reader["section_year"].ToString();
                                string to = reader["parent_contact"].ToString();
                                string subject = "Student Attendance";
                                string body = $"{studentName} from section {section} did not attend class {getSchedID}";

                                string email = "techtitaninnovations@outlook.com";
                                string password = "techtitansecurity135";
                                string host = "smtp-mail.outlook.com";
                                int port = 587;

                                using (MailMessage mail = new MailMessage(email, to, subject, body))
                                {
                                    using (SmtpClient smtp = new SmtpClient(host, port))
                                    {
                                        smtp.UseDefaultCredentials = false;
                                        smtp.EnableSsl = true;
                                        smtp.Credentials = new NetworkCredential(email, password);
                                        await smtp.SendMailAsync(mail);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while sending emails: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async Task SendMessageInstructorAsync()
        {
            string loadAbsentQuery = "SELECT tbl_instructors.*, schedule_id, tbl_departments.department, tbl_departments.dept_email FROM tbl_instructors JOIN tbl_schedule on tbl_instructors.instructor_id = tbl_schedule.instructor_id JOIN tbl_departments on tbl_instructors.department = tbl_departments.department WHERE tbl_schedule.schedule_id = @messageSchedID";

            string getSchedID = lblSchedID.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(loadAbsentQuery, conn))
                {
                    command.Parameters.AddWithValue("@messageSchedID", getSchedID);

                    await conn.OpenAsync();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            string InstructorName = reader["lastname"].ToString() + ", " + reader["firstname"].ToString() + " " + reader["middlename"].ToString();
                            string section = reader["advisory"].ToString();
                            string to = reader["dept_email"].ToString();
                            string subject = "Instructor Attendance";
                            string body = $"{InstructorName} of section {section} did not conduct class {getSchedID}";

                            string email = "techtitaninnovations@outlook.com";
                            string password = "techtitansecurity135";
                            string host = "smtp-mail.outlook.com";
                            int port = 587;

                            try
                            {
                                using (MailMessage mail = new MailMessage(email, to, subject, body))
                                {
                                    using (SmtpClient smtp = new SmtpClient(host, port))
                                    {
                                        smtp.UseDefaultCredentials = false;
                                        smtp.EnableSsl = true;
                                        smtp.Credentials = new NetworkCredential(email, password);
                                        await smtp.SendMailAsync(mail);
                                    }
                                }
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

        private async Task PoolSchedule()
        {
            string query = $"SELECT tbl_schedule.* FROM tbl_schedule JOIN tbl_instructors on tbl_schedule.instructor_id = tbl_instructors.instructor_id WHERE room = '{selected_room}' ORDER BY start_hour ASC, start_minute ASC;";

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

        private async void FormRoomScanner_Shown(object sender, EventArgs e)
        {
            await PoolSchedule();
            await PoolStudents();
            await PoolInstructors();
            await PoolEvents();
        }

        private DataTable imageDataTable;
        private int currentIndex = 0;

        private void StartCarousel()
        {
            imageDataTable = FetchImageDataFromJson();
            DisplayCurrentImage();

            timerCarousel.Interval = 6000;
            timerCarousel.Tick += timerCarousel_Tick;
            timerCarousel.Start();
        }

        private void timerCarousel_Tick(object sender, EventArgs e)
        {
            if (imageDataTable.Rows.Count > 0)
            {
                currentIndex = (currentIndex + 1) % imageDataTable.Rows.Count;
                DisplayCurrentImage();
            }
            else
            {
                currentIndex = 0;
            }
        }


        private DataTable FetchImageDataFromJson()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string jsonFilePath = "eventpics.json";
                string jsonData = File.ReadAllText(jsonFilePath);
                dataTable = JsonConvert.DeserializeObject<DataTable>(jsonData);
            }
            catch (Exception ex)
            {

            }

            return dataTable;
        }

        private void DisplayCurrentImage()
        {
            try
            {
                if (imageDataTable != null && imageDataTable.Rows.Count > 0)
                {
                    string base64ImageData = imageDataTable.Rows[currentIndex]["event_pic"].ToString();
                    byte[] imageData = Convert.FromBase64String(base64ImageData);
                    picEvents.Image = Image.FromStream(new MemoryStream(imageData));
                }
                else
                {
                    picEvents.Image = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
