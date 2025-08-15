using AutoMapper;

namespace BaseArchitecture.Core.Mapping.UserMapping
{
    public partial class UserMapping : Profile
    {
        #region Constructor
        public UserMapping()
        {
            MappingFromUserToUserFullDataDto();
            MappingFromUpdateUserCommandRequestModelToUser();
        }
        #endregion
    }
}
