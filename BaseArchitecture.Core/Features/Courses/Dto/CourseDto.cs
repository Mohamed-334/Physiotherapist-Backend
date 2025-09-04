namespace PhysiotherapistProject.Core.Features.Courses.Dto
{
    public class CourseDto
    {
        public int Id { get; set; }
        public int TotalSessions { get; set; }
        public int TotalCompletedSessions { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
    }
}
