using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhysiotherapistProject.Domain.Entities
{
    public class Clinic : BaseEntityWithName
    {
        public TimeSpan? StartHour { get; set; }
        public TimeSpan? EndHour { get; set; }

        [ForeignKey("ClinicManger")]
        public int? ClinicMangerId { get; set; }
        public User? ClinicManger { get; set; }

        public string? ClinicImage { get; set; }
        public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();

    }
}
