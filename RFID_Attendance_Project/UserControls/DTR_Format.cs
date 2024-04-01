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
            string loadstudents_query = "SELECT DAY(STR_TO_DATE(`date`, '%W, %M %d, %Y')) AS day, CONCAT(TIME_FORMAT(MIN(CASE WHEN STR_TO_DATE(time_in, '%h:%i:%s %p') < STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_in, '%h:%i:%s %p') END), '%h:%i'), CASE WHEN MIN(CASE WHEN STR_TO_DATE(time_in, '%h:%i:%s %p') < STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_in, '%h:%i:%s %p') END) < STR_TO_DATE('12:00:00', '%h:%i:%s') THEN ' AM' ELSE ' PM' END) AS arrivalAM, CONCAT(TIME_FORMAT(MAX(CASE WHEN STR_TO_DATE(time_out, '%h:%i:%s %p') < STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_out, '%h:%i:%s %p') END), '%h:%i'), CASE WHEN MAX(CASE WHEN STR_TO_DATE(time_out, '%h:%i:%s %p') < STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_out, '%h:%i:%s %p') END) < STR_TO_DATE('12:00:00', '%h:%i:%s') THEN ' AM' ELSE ' PM' END) AS departureAM, CONCAT(TIME_FORMAT(MIN(CASE WHEN STR_TO_DATE(time_in, '%h:%i:%s %p') >= STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_in, '%h:%i:%s %p') END), '%h:%i'), CASE WHEN MIN(CASE WHEN STR_TO_DATE(time_in, '%h:%i:%s %p') >= STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_in, '%h:%i:%s %p') END) < STR_TO_DATE('12:00:00', '%h:%i:%s') THEN ' AM' ELSE ' PM' END) AS arrivalPM, CONCAT(TIME_FORMAT(MAX(CASE WHEN STR_TO_DATE(time_out, '%h:%i:%s %p') >= STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_out, '%h:%i:%s %p') END), '%h:%i'),  CASE WHEN MAX(CASE WHEN STR_TO_DATE(time_out, '%h:%i:%s %p') >= STR_TO_DATE('12:00:00 PM', '%h:%i:%s %p') THEN STR_TO_DATE(time_out, '%h:%i:%s %p') END) < STR_TO_DATE('12:00:00', '%h:%i:%s') THEN ' AM' ELSE ' PM' END) AS departurePM FROM tbl_schoolattendance WHERE `date` LIKE '%" + PopGenerateDTR.generate_month + "%' AND `date` LIKE '%" + PopGenerateDTR.generate_year + "%' AND fullname = '" + FormLogin.username_display +"' GROUP BY DAY(STR_TO_DATE(`date`, '%W, %M %d, %Y'));";

            DataTable dt = new DataTable();
            dt.Columns.Add("Day", typeof(int));
            dt.Columns.Add("ArrivalAM", typeof(string));
            dt.Columns.Add("DepartureAM", typeof(string));
            dt.Columns.Add("ArrivalPM", typeof(string));
            dt.Columns.Add("DeparturePM", typeof(string));

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

            dgvDTR.DataSource = dt;
        }

        private void dgvDTR_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDTR.ClearSelection();
        }

        private void dgvDTR_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDTR.ClearSelection();
        }
    }
}
