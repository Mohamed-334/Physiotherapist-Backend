using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Sessions.Dto;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.SessionMapping
{
    public partial class SessionMapping
    {
        public void MappingFromSessionToSessionFullDataDto()
        {
            CreateMap<Session, SessionFullDataDto>()
                .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Course.Clinic.NameLocalization))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Course.User.UserName))
                .AfterMap<MetaMappingDataBasedOnSource<Session, SessionFullDataDto>>();
        }
    }
}
