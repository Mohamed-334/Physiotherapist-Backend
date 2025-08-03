using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationMapping
    {
        public void MapFromSignupCommandRequestModelToUser()
        {
            CreateMap<SignUpCommandRequestModel, User>();
        }
    }
}
