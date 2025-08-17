using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using PhysiotherapistProject.Core.Features.UserCourses.Dto;

namespace PhysiotherapistProject.Core.Features.UserCourses.Queries.RequestModels
{
    public class GetUserCoursePaginatedListQueryRequestModel : IRequest<Response<PaginatedList<UserCourseDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetUserCoursePaginatedListQueryRequestModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
