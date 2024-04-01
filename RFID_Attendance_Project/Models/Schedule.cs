using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFID_Attendance_Project.Models
{
    public class Schedule
    {
        [Required(ErrorMessage = "Schedule ID is Required")]
        public string SchedID { get; set; }

        [Required(ErrorMessage = "Schedule Description is Required")]
        public string SchedDesc { get; set; }

        [Required(ErrorMessage = "Section is Required")]
        public string Section { get; set; }

        [Required(ErrorMessage = "Start Hour Time is Required")]
        [RegularExpression("^(0?([0-9]|1[0-9]|2[0-3]))$", ErrorMessage = "Start Hour Time must be a valid hour between 0 and 24.")]
        public string StartTimeHr { get; set; }

        [Required(ErrorMessage = "Start Minute Time is Required")]
        [RegularExpression("^(0?([0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]))$", ErrorMessage = "Start Minute Time must be a valid minute between 0 and 59.")]
        public string StartTimeMin { get; set; }

        [Required(ErrorMessage = "End Hour Time is Required")]
        [RegularExpression("^(0?([0-9]|1[0-9]|2[0-3]))$", ErrorMessage = "Start Hour Time must be a valid hour between 0 and 24.")]
        public string EndTimeHr { get; set; }

        [Required(ErrorMessage = "End Minute Time is Required")]
        [RegularExpression("^(0?([0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]))$", ErrorMessage = "End Minute Time must be a valid hour between 0 and 59.")]
        public string EndTimeMin { get; set; }

        [Required(ErrorMessage = "Day is Required")]
        public string Day { get; set; }

        [Required(ErrorMessage = "Room is Required")]
        public string Room { get; set; }
    }
}
