using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhysiotherapistProject.Domain.Entities
{
    public class UserCourse : BaseEntity
    {

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int CompletedSessions { get; set; }
        public ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();
    }
}
