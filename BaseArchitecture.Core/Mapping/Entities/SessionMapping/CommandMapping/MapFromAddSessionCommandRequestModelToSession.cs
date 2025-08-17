using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Sessions.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.SessionMapping
{
    public partial class SessionMapping
    {
        public void MapFromAddSessionCommandRequestModelToSession()
        {
            CreateMap<AddSessionCommandRequestModel, Session>()
                .AfterMap<MetaMappingDataBasedOnDestination<AddSessionCommandRequestModel, Session>>();
        }
    }
}
