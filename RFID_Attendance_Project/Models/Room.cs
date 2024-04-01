using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFID_Attendance_Project.Models
{
    public class Room
    {
        [Required(ErrorMessage = "Room ID is Required")]
        public string Room_ID { get; set; }
    }
}
