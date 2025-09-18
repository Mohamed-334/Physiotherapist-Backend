namespace PhysiotherapistProject.Core.Features.Clinics.Dto
{
    public class ClinicDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameLocalization { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public int? ClinicMangerId { get; set; }
        public string? ClinicImage { get; set; }
    }
}
