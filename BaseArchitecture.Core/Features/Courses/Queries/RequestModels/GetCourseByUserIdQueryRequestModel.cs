using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Courses.Dto;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.RequestModels
{
    public class GetCourseByUserIdQueryRequestModel : IRequest<Response<List<CourseDto>>>
    {
        public int Id { get; set; }
        public GetCourseByUserIdQueryRequestModel(int id)
        {
            Id = id;
        }
    }
}
