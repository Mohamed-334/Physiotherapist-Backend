using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace PhysiotherapistProject.Core.Features.Sessions.Dto
{
    public class SessionDto
    {
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public string Status { get; set; } = SessionStatusEnum.Pending.ToString();
        public string StatusLocalization { get; set; } = SessionStatusEnum.Pending.GetDisplayName()!;
        public int StatusCode { get; set; } = (int)SessionStatusEnum.Pending;
        public string? TreatmentNotes { get; set; }
        public int UserCourseId { get; set; }
    }
}
