using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseArchitecture.Core.Mapping.UserMapping
{
    public partial class UserMapping : Profile
    {
        public UserMapping()
        {
            // CreateMap<SourceType, DestinationType>();
            // Example:
            // CreateMap<User, UserDto>()
            //     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
