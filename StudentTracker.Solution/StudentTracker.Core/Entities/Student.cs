using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker.Core.Entities
{
    public class Student
    {
        [Key]
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Level { get; set; }
        public string Group { get; set; }
        public string FaceId { get; set; }
        public string? MacId { get; set; }

        //Navigation Properties
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();

    }
}
