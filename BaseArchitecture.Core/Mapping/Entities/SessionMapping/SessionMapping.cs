using AutoMapper;

namespace PhysiotherapistProject.Core.Mapping.Entities.SessionMapping
{
    public partial class SessionMapping : Profile
    {
        public SessionMapping()
        {
            MapFromSessionToSessionDto();
            MapFromAddSessionCommandRequestModelToSession();
            MapFromUpdateSessionCommandRequestModelToSession();
            MappingFromSessionToSessionFullDataDto();
        }
    }
}
