using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Courses.Dto;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.RequestModels
{
    public class GetCourseByIdQueryRequestModel : IRequest<Response<CourseDto>>
    {
        public int Id { get; set; }
        public GetCourseByIdQueryRequestModel(int id)
        {
            Id = id;
        }
    }
}
