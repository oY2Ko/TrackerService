using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TrackerService.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        StudentProfile studentProfile { get; set; }

    }


    public class StudentProfile
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string GroupNumber { get; set; }
    }
}
