using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels
{
    public class HardDeleteCourseCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public HardDeleteCourseCommandRequestModel(int id)
        {
            Id = id;
        }
    }
}
