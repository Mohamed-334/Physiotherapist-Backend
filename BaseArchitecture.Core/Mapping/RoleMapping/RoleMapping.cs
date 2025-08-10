using AutoMapper;

namespace BaseArchitecture.Core.Mapping.RoleMapping
{
    public partial class RoleMapping : Profile
    {
        public RoleMapping()
        {
            MapFromAddRoleCommandRequestModelToRoleEntity();
            MapFromUpdateRoleCommandRequestModelToRoleEntity();
            MappingFromRoleToRoleFullDataDto();
        }
    }
}
