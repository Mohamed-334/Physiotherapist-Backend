using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels
{
    public class AddUserCourseCommandRequestModel : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int CompletedSessions { get; set; }
    }
}
