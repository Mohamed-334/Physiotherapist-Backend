using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels
{
    public class SoftDeleteAndActivateCourseCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public SoftDeleteAndActivateCourseCommandRequestQuery(int id)
        {
            Id = id;
        }
    }
}
