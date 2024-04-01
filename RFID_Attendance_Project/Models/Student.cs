using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RFID_Attendance_Project.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Student ID is Required")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "RFID Card is Required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric values are allowed in RFID")]
        public string CardId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name is Required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Section Year is Required")]
        public string SectionYear { get; set; }

        [Required(ErrorMessage = "Contact is Required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Only numeric values and the plus symbol are allowed in Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Parent Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string ParentContact { get; set; }
    }
}
