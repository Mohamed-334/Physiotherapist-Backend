using BaseArchitecture.Core.Features.ApplicationUser.Queries.DTO;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;

namespace BaseArchitecture.Core.Features.ApplicationUser.Queries.RequestModels
{
    public class GetUsersPaginatedListQueryRequestModel : IRequest<Response<PaginatedList<UserFullDataDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public GetUsersPaginatedListQueryRequestModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetUsersPaginatedListQueryRequestModel() { }
    }
}
