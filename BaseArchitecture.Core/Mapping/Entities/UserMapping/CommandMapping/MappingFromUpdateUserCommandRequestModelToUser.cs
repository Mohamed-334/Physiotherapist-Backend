using BaseArchitecture.Core.Features.ApplicationUser.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.UserMapping
{
    public partial class UserMapping
    {
        public void MappingFromUpdateUserCommandRequestModelToUser()
        {
            CreateMap<UpdateUserCommandRequestQuery, User>()
                .AfterMap<MetaMappingDataBasedOnDestination<UpdateUserCommandRequestQuery, User>>();

        }
    }
}
