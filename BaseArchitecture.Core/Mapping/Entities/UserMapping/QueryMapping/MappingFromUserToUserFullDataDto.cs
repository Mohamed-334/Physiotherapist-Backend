using BaseArchitecture.Core.Features.ApplicationUser.DTO;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.UserMapping
{
    public partial class UserMapping
    {
        public void MappingFromUserToUserFullDataDto()
        {
            CreateMap<User, UserFullDataDto>()
                .AfterMap<MetaMappingDataBasedOnSource<User, UserFullDataDto>>();
        }
    }

}
