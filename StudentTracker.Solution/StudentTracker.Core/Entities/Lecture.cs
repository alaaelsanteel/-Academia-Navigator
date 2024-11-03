using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker.Core.Entities
{
    public class Lecture : BaseEntity
    {
        public string Day { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }
        public bool ProfessorAttended { get; set; }

        //Foreign Keys
        public string? ProfessorNationalId { get; set; }
        public int CourseId { get; set; }
        public int? HallId { get; set; }

        //Navigation Properties
        public virtual Professor Professor { get; set; }
        public virtual Course Course { get; set; }
        public virtual  Hall Hall { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>(); //
    }
}
