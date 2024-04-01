using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFID_Attendance_Project.Models
{
    public class Instructor
    {
        [Required(ErrorMessage = "Instructor ID is Required")]
        public string InstructorId { get; set; }

        [Required(ErrorMessage = "RFID Card is Required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric values are allowed in RFID")]
        public string CardId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name is Required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Advisory is Required")]
        public string Advisory { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Contact is Required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Only numeric values and the plus symbol are allowed in Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
