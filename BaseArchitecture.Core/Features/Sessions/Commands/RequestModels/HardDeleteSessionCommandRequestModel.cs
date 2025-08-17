using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Sessions.Commands.RequestModels
{
    public class HardDeleteSessionCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public HardDeleteSessionCommandRequestModel(int id)
        {
            Id = id;
        }
    }
}
