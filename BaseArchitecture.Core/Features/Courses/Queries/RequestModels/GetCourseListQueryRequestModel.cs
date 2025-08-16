using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Courses.Dto;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.RequestModels
{
    public class GetCourseListQueryRequestModel : IRequest<Response<List<CourseDto>>>
    {
    }
}
