namespace StudentTracker.APIs.DTOs
{
    public class CourseLecturesDto
    {
        public string CourseTitle { get; set; }
        public List<LectureAttendanceDto> Lectures { get; set; }
    }
}
