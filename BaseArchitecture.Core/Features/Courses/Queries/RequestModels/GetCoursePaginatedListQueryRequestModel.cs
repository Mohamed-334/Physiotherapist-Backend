using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using PhysiotherapistProject.Core.Features.Courses.Dto;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.RequestModels
{
    public class GetCoursePaginatedListQueryRequestModel : IRequest<Response<PaginatedList<CourseDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetCoursePaginatedListQueryRequestModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
