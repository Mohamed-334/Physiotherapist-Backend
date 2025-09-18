namespace PhysiotherapistProject.Core.Features.Sessions.Dto
{
    public class SessionStatisticsDto
    {
        public int TotalSessionToday { get; set; }
        public int TotalCancelledSessionToday { get; set; }
        public int TotalPatientToday { get; set; }
        public int TotalCompletedToday { get; set; }
    }
}
