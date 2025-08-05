using BaseArchitecture.Core.Features.ApplicationUser.Queries.DTO;
using BaseArchitecture.Domain.Entities;

namespace BaseArchitecture.Core.Mapping.UserMapping
{
    public partial class UserMapping
    {
        public void MappingFromUserToUserFullDataDto()
        {
            CreateMap<User, UserFullDataDto>()
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
