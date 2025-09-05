using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels
{
    public class UpdateCourseCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
        public int UserId { get; set; }
        public int ClinicId { get; set; }
        public int TotalSessions { get; set; }
        public int TotalCompletedSessions { get; set; }
    }
}
