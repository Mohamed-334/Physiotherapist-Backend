using BaseArchitecture.Core.Features.Roles.Dto;
using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.ApplicationUser.Queries.RequestModels
{
    public class GetUserRolesQueryRequestModel : IRequest<Response<List<RoleFullDataDto>>>
    {
        public int UserId { get; set; }
    }
}
