using BaseArchitecture.Core.Features.Roles.Dto;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;

namespace BaseArchitecture.Core.Features.Roles.Queries.RequestModels
{
    public class GetRolesPaginatedListQueryRequestModel : IRequest<Response<PaginatedList<RoleFullDataDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public GetRolesPaginatedListQueryRequestModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetRolesPaginatedListQueryRequestModel() { }
    }
}
