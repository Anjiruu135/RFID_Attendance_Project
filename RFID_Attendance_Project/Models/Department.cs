using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFID_Attendance_Project.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department ID is Required")]
        public string Dept_ID { get; set; }

        [Required(ErrorMessage = "Department Contact is Required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Dept_email { get; set; }
    }
}
