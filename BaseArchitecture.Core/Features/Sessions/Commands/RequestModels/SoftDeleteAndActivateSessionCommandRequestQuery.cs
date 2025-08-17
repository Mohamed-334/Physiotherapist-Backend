using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Sessions.Commands.RequestModels
{
    public class SoftDeleteAndActivateSessionCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public SoftDeleteAndActivateSessionCommandRequestQuery(int id)
        {
            Id = id;
        }
    }
}
