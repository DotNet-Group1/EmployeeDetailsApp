using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetailsApp.Models
{
    public class Teacher
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
    }
}