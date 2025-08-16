using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;

namespace PhysiotherapistProject.Domain.Entities
{
    public class Course : BaseEntityWithName
    {
        public int TotalSessions { get; set; }
        public int TotalCompletedSessions { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; } = new HashSet<UserCourse>();
    }
}
