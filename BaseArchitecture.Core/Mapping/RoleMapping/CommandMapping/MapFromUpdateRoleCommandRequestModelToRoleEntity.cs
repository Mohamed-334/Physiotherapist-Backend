using BaseArchitecture.Core.Features.Roles.Commands.RequestModels;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.RoleMapping
{
    public partial class RoleMapping
    {
        public void MapFromUpdateRoleCommandRequestModelToRoleEntity()
        {
            CreateMap<UpdateRoleCommandRequestModel, Role>()
            .AfterMap((RequestModel, entity) =>
            {
                if (entity.CreationDate == null || entity.CreationDate == default(DateTime))
                    entity.CreationDate = DateTime.Now;
                else
                    entity.ModificationDate = DateTime.Now;
            });
        }
    }
}
