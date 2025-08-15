using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationMapping
    {
        #region Methods
        public void MapFromSignupCommandRequestModelToUser()
        {
            CreateMap<SignUpCommandRequestModel, User>()
                .AfterMap<MetaMappingDataBasedOnDestination<SignUpCommandRequestModel, User>>();
        }
        #endregion
    }
}
