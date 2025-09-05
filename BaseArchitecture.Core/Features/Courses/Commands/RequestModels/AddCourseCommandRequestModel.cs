using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels
{
    public class AddCourseCommandRequestModel : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string? NameLocalization { get; set; }
        public int UserId { get; set; }
        public int ClinicId { get; set; }
        public int TotalSessions { get; set; }
        public int TotalCompletedSessions { get; set; }

        public AddCourseCommandRequestModel(string name, string? nameLocalization, int totalSessions, int totalCompletedSessions, int clinicId)
        {
            Name = name;
            NameLocalization = nameLocalization;
            TotalSessions = totalSessions;
            TotalCompletedSessions = totalCompletedSessions;
            ClinicId = clinicId;
        }
    }
}
