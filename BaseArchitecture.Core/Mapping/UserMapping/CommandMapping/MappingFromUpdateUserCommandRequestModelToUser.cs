using BaseArchitecture.Core.Features.ApplicationUser.Commands.RequestModels;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.UserMapping
{
    public partial class UserMapping
    {
        public void MappingFromUpdateUserCommandRequestModelToUser()
        {
            CreateMap<UpdateUserCommandRequestQuery, User>()
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
