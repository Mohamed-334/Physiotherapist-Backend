using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhysiotherapistProject.Domain.Entities
{
    public class Report : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
