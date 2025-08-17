using BaseArchitecture.Domain.Shared.BaseEntity.Implementations;
using System.ComponentModel.DataAnnotations.Schema;
using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace PhysiotherapistProject.Domain.Entities
{
    public class Session : BaseEntityWithName
    {
        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public string Status { get; set; } = SessionStatusEnum.Pending.ToString();
        public string StatusLocalization { get; set; } = SessionStatusEnum.Pending.GetDisplayName()!;
        public int StatusCode { get; set; } = (int)SessionStatusEnum.Pending;
        public string? TreatmentNotes { get; set; }
        [ForeignKey("UserCourse")]
        public int UserCourseId { get; set; }
        public UserCourse? UserCourse { get; set; }
    }
}
