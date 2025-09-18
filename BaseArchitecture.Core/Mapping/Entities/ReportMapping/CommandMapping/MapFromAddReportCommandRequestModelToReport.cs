using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Reports.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.ReportMapping
{
    public partial class ReportMapping
    {
        public void MapFromAddReportCommandRequestModelToReport()
        {
            CreateMap<AddReportCommandRequestModel, Report>()
                .AfterMap<MetaMappingDataBasedOnDestination<AddReportCommandRequestModel, Report>>();
        }
    }
}
