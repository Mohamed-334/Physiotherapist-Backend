namespace PhysiotherapistProject.Core.Features.UserCourses.Dto
{
    public class UserCourseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? User { get; set; }
        public int CourseId { get; set; }
        public string? Course { get; set; }
        public int CompletedSessions { get; set; }
    }
}
