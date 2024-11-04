using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }

        //Navigation Properties
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();
    }
}
