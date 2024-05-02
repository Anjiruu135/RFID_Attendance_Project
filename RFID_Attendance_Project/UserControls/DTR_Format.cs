using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID_Attendance_Project.Models;
using RFID_Attendance_Project.Modules;
using MySql.Data.MySqlClient;

namespace RFID_Attendance_Project.UserControls
{
    public partial class DTR_Format : UserControl
    {
        string connectionString = Database.connectionString;

        public DTR_Format()
        {
            InitializeComponent();
            dgvDTR.CellEnter += dgvDTR_CellEnter;
            dgvDTR.DataBindingComplete += dgvDTR_DataBindingComplete;
        }

        private void DTR_Format_Load(object sender, EventArgs e)
        {
            LoadDTR();
            string MonthYearFormat = $"{PopGenerateDTR.generate_month}, {PopGenerateDTR.generate_year}";
            lblNamePlace.Text = FormLogin.username_display;
            lblMonthPlace.Text = MonthYearFormat;
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

        private async void LoadDTR()
        {
            string loadstudents_query = "SELECT DAY(STR_TO_DATE(`date`, '%W, %M %d, %Y')) AS day, CONCAT(TIME_FORMAT(MIN(CASE WHEN STR_TO_DATE(time_in, '%h:%i:%s %p') < STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_in, '%h:%i:%s %p') END), '%h:%i %p')) AS arrivalAM, CONCAT(TIME_FORMAT(MAX(CASE WHEN STR_TO_DATE(time_out, '%h:%i:%s %p') < STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_out, '%h:%i:%s %p') END), '%h:%i %p')) AS departureAM, CONCAT(TIME_FORMAT(MIN(CASE WHEN STR_TO_DATE(time_in, '%h:%i:%s %p') >= STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_in, '%h:%i:%s %p') END), '%h:%i %p')) AS arrivalPM, CONCAT(TIME_FORMAT(MAX(CASE WHEN STR_TO_DATE(time_out, '%h:%i:%s %p') >= STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_out, '%h:%i:%s %p') END), '%h:%i %p')) AS departurePM FROM tbl_schoolattendance WHERE `date` LIKE '%" + PopGenerateDTR.generate_month + "%' AND `date` LIKE '%" + PopGenerateDTR.generate_year + "%' AND fullname = '" + FormLogin.username_display + "' GROUP BY DAY(STR_TO_DATE(`date`, '%W, %M %d, %Y'));";

            DataTable dt = new DataTable();
            dt.Columns.Add("Day", typeof(int));
            dt.Columns.Add("ArrivalAM", typeof(string));
            dt.Columns.Add("DepartureAM", typeof(string));
            dt.Columns.Add("ArrivalPM", typeof(string));
            dt.Columns.Add("DeparturePM", typeof(string));
            dt.Columns.Add("TotalHours", typeof(string));
            dt.Columns.Add("TotalMinutes", typeof(string));

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

            for (int i = 1; i <= 31; i++)
            {
                if (dt.Select($"Day = {i}").Length == 0)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["Day"] = i;
                    dt.Rows.Add(newRow);
                }
            }

            dt.DefaultView.Sort = "Day ASC";
            dt = dt.DefaultView.ToTable();

            foreach (DataRow row in dt.Rows)
            {
                int totalHoursAM = 0, totalMinutesAM = 0, totalHoursPM = 0, totalMinutesPM = 0;

                if (!string.IsNullOrEmpty(row["ArrivalAM"].ToString()) && !string.IsNullOrEmpty(row["DepartureAM"].ToString()))
                {
                    TimeSpan amSession = DateTime.Parse(row["DepartureAM"].ToString()).Subtract(DateTime.Parse(row["ArrivalAM"].ToString()));
                    totalHoursAM += amSession.Hours;
                    totalMinutesAM += amSession.Minutes;
                }
                if (!string.IsNullOrEmpty(row["ArrivalPM"].ToString()) && !string.IsNullOrEmpty(row["DeparturePM"].ToString()))
                {
                    TimeSpan pmSession = DateTime.Parse(row["DeparturePM"].ToString()).Subtract(DateTime.Parse(row["ArrivalPM"].ToString()));
                    totalHoursPM += pmSession.Hours;
                    totalMinutesPM += pmSession.Minutes;
                }

                int totalHours = totalHoursAM + totalHoursPM;
                int totalMinutes = totalMinutesAM + totalMinutesPM;

                if (totalHours == 0 && totalMinutes == 0)
                {
                    row["TotalHours"] = "";
                    row["TotalMinutes"] = "";
                }
                else
                {
                    row["TotalHours"] = $"{totalHours} hours";
                    row["TotalMinutes"] = $"{totalMinutes} minutes";
                }
            }

            dgvDTR.DataSource = dt;

            int AlltotalHours = 0;
            int AlltotalMinutes = 0;

            foreach (DataRow row in dt.Rows)
            {
                int rowTotalHours = 0;
                int rowTotalMinutes = 0;

                if (!string.IsNullOrEmpty(row["TotalHours"].ToString()))
                {
                    string[] hoursParts = row["TotalHours"].ToString().Split(' ');
                    int.TryParse(hoursParts[0], out rowTotalHours);
                }

                if (!string.IsNullOrEmpty(row["TotalMinutes"].ToString()))
                {
                    string[] minutesParts = row["TotalMinutes"].ToString().Split(' ');
                    int.TryParse(minutesParts[0], out rowTotalMinutes);
                }

                AlltotalHours += rowTotalHours;
                AlltotalMinutes += rowTotalMinutes;
            }

            AlltotalHours += AlltotalMinutes / 60;
            AlltotalMinutes %= 60;

            lblTotalHours.Text = $"{AlltotalHours}";
            lblTotalMinutes.Text = $"{AlltotalMinutes}";
        }

        private void dgvDTR_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDTR.ClearSelection();
        }

        private void dgvDTR_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDTR.ClearSelection();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
