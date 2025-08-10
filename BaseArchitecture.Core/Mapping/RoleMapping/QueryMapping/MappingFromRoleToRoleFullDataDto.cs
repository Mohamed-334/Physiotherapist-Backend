using BaseArchitecture.Core.Features.Roles.Dto;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.RoleMapping
{
    public partial class RoleMapping
    {
        public void MappingFromRoleToRoleFullDataDto()
        {
            CreateMap<Role, RoleFullDataDto>()
                .AfterMap((RequestModel, entity) =>
                {
                    if (RequestModel.CreationDate == null || RequestModel.CreationDate == default(DateTime))
                        RequestModel.CreationDate = DateTime.Now;
                    else
                        RequestModel.ModificationDate = DateTime.Now;
                });
        }
    }

}
