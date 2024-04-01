using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_Attendance_Project
{
    public partial class PopDateSelect : Form
    {
        public PopDateSelect()
        {
            InitializeComponent();
            dateTimePicker.MaxDate = DateTime.Today;
            dateTimePicker.Value = DateTime.Today;
        }

        public static string PublicSelectedDate;

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
            DateTime selectedDate = dateTimePicker.Value;

            string selectedYear = selectedDate.ToString("yyyy");
            string selectedMonth = selectedDate.ToString("MM");
            string selectedDay = selectedDate.ToString("dd");

            PublicSelectedDate = $"{selectedYear}-{selectedMonth}-{selectedDay}";
            Console.WriteLine(PublicSelectedDate);
            this.Close();
        }
    }
}
