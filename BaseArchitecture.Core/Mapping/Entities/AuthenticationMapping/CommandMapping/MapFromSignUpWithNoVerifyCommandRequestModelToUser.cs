using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationMapping
    {
        public void MapFromSignUpWithNoVerifyCommandRequestModelToUser()
        {
            CreateMap<SignUpWithNoVerifyCommandRequestModel, User>()
                .AfterMap<MetaMappingDataBasedOnDestination<SignUpWithNoVerifyCommandRequestModel, User>>();
        }
    }
}
