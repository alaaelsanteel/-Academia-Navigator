using StudentTracker.Core.Entities;

namespace StudentTracker.APIs.DTOs
{
    public class StudentToReturnDto
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public ICollection<string> Courses { get; set; }
    }
}
