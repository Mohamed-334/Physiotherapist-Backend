using BaseArchitecture.Core.Shared.Models;
using MediatR;
using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace PhysiotherapistProject.Core.Features.Reports.Commands.RequestModels
{
    public class AddReportCommandRequestModel : IRequest<Response<string>>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message  { get; set; }
    }
}
