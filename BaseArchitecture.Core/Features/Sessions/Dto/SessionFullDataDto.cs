using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace PhysiotherapistProject.Core.Features.Sessions.Dto
{
    public class SessionFullDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
        public int SessionNumber { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan SessionTime { get; set; }
        public string Status { get; set; } = SessionStatusEnum.Pending.ToString();
        public string StatusLocalization { get; set; } = SessionStatusEnum.Pending.GetDisplayName()!;
        public int StatusCode { get; set; } = (int)SessionStatusEnum.Pending;
        public string? TreatmentNotes { get; set; }
        public string? MedicalDiagnosis { get; set; }
        public int CourseId { get; set; }

        public string? PatientName { get; set; }
        public string? ClinicName { get; set; }
    }
}
