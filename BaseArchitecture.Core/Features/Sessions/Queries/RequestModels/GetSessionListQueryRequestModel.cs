using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Sessions.Dto;

namespace PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels
{
    public class GetSessionListQueryRequestModel : IRequest<Response<List<SessionDto>>>
    {
    }
}
