using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels
{
    public class HardDeleteUserCourseCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public HardDeleteUserCourseCommandRequestModel(int id)
        {
            Id = id;
        }
    }
}
