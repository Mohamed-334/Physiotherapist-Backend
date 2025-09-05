using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Sessions.Dto;

namespace PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels
{
    public class GetSessionByCourseIdQueryRequestModel : IRequest<Response<List<SessionDto>>>
    {
        public int Id { get; set; }
        public GetSessionByCourseIdQueryRequestModel(int id)
        {
            Id = id;
        }
    }
}
