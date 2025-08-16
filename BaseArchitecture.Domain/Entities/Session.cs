using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhysiotherapistProject.Domain.Entities
{
    public class Session : BaseEntity
    {
        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string? TreatmentNotes { get; set; }
        [ForeignKey("UserCourse")]
        public int UserCourseId { get; set; }
        public UserCourse? UserCourse { get; set; }
    }
}
