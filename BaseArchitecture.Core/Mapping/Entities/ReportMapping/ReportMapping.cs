using AutoMapper;

namespace PhysiotherapistProject.Core.Mapping.Entities.ReportMapping
{
    public partial class ReportMapping : Profile
    {
        public ReportMapping()
        {
            MapFromAddReportCommandRequestModelToReport();
        }
    }
}
