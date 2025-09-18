using AutoMapper;

namespace BaseArchitecture.Core.Mapping.AuthenticationMapping
{
    public partial class AuthenticationMapping : Profile
    {
        #region Constructor
        public AuthenticationMapping()
        {
            MapFromSignupCommandRequestModelToUser();
            MapFromSignUpWithNoVerifyCommandRequestModelToUser();
        }
        #endregion
    }
}
