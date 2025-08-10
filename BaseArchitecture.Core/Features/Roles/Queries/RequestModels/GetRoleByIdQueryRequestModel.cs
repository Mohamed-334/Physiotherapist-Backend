using BaseArchitecture.Core.Features.Roles.Dto;
using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Roles.Queries.RequestModels
{
    public class GetRoleByIdQueryRequestModel : IRequest<Response<RoleFullDataDto>>
    {
        public int RoleId { get; set; }

    }
}
