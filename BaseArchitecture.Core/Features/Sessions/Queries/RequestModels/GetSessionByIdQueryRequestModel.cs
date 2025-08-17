using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Sessions.Dto;

namespace PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels
{
    public class GetSessionByIdQueryRequestModel : IRequest<Response<SessionDto>>
    {
        public int Id { get; set; }
        public GetSessionByIdQueryRequestModel(int id)
        {
            Id = id;
        }
    }
}
