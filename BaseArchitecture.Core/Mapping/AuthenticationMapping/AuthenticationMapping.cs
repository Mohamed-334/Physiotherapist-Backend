using AutoMapper;

namespace BaseArchitecture.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationMapping : Profile
    {
        public AuthenticationMapping()
        {
            // CreateMap<SourceType, DestinationType>();
            // Example:
            // CreateMap<User, UserDto>()
            //     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            MapFromSignupCommandRequestModelToUser();
        }
    }
}
