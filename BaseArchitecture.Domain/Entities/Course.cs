using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhysiotherapistProject.Domain.Entities
{
    public class Course : BaseEntityWithName
    {
        public int TotalSessions { get; set; }
        public int TotalCompletedSessions { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Session>? Sessions { get; set; } = new HashSet<Session>();

    }
}
