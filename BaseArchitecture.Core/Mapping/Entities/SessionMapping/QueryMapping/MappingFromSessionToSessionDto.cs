using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Sessions.Dto;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.SessionMapping
{
    public partial class SessionMapping
    {
        public void MapFromSessionToSessionDto()
        {
            CreateMap<Session, SessionDto>()
                .AfterMap<MetaMappingDataBasedOnSource<Session, SessionDto>>();
        }
    }
}
