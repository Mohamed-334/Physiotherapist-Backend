using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels
{
    public class UpdateUserCourseCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int CompletedSessions { get; set; }
    }
}
