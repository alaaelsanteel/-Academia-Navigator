namespace StudentTracker.APIs.DTOs
{
    public class LectureToReturnDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ProfessorName { get; set; }
        public string CourseTitle { get; set; }
        public string HallName { get; set; }
        public int HallId { get; set; }
    }
}
