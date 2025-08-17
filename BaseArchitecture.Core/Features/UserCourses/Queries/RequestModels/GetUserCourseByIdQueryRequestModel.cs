using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.UserCourses.Dto;

namespace PhysiotherapistProject.Core.Features.UserCourses.Queries.RequestModels
{
    public class GetUserCourseByIdQueryRequestModel : IRequest<Response<UserCourseDto>>
    {
        public int Id { get; set; }
        public GetUserCourseByIdQueryRequestModel(int id)
        {
            Id = id;
        }
    }
}
