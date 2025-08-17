using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.UserCourses.Dto;

namespace PhysiotherapistProject.Core.Features.UserCourses.Queries.RequestModels
{
    public class GetUserCourseListQueryRequestModel : IRequest<Response<List<UserCourseDto>>>
    {
    }
}
