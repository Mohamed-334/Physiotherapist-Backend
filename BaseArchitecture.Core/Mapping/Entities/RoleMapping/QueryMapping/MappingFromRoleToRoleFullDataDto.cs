using BaseArchitecture.Core.Features.Roles.Dto;
using BaseArchitecture.Core.Mapping.Shared;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.RoleMapping
{
    public partial class RoleMapping
    {
        #region Methods
        public void MappingFromRoleToRoleFullDataDto()
        {
            CreateMap<Role, RoleFullDataDto>()
                .AfterMap<MetaMappingDataBasedOnSource<Role, RoleFullDataDto>>();
        }
        #endregion
    }

}
