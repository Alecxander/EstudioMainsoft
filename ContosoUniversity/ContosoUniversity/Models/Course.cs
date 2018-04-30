using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;


namespace ContosoUniversity.Models
{
    public class Course
    {
        [Key]
        public int CoursesID { get; set; }
        public string Titles { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}