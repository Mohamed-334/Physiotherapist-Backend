using BaseArchitecture.Core.Features.Roles.Commands.RequestModels;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.RoleMapping
{
    public partial class RoleMapping
    {
        #region Methods
        public void MapFromUpdateRoleCommandRequestModelToRoleEntity()
        {
            CreateMap<UpdateRoleCommandRequestModel, Role>()
            .AfterMap<MetaMappingDataBasedOnDestination<UpdateRoleCommandRequestModel, Role>>();
        }
        #endregion
    }
}
