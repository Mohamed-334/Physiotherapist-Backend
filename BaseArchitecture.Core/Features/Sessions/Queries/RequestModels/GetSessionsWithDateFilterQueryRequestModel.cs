using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Sessions.Dto;

namespace PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels
{
    public class GetSessionsWithDateFilterQueryRequestModel : IRequest<Response<List<SessionFullDataDto>>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
    }
}
