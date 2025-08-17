using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels
{
    public class SoftDeleteAndActivateUserCourseCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public SoftDeleteAndActivateUserCourseCommandRequestQuery(int id)
        {
            Id = id;
        }
    }
}
