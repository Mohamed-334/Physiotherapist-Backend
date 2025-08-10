using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Roles.Commands.RequestModels
{
    public class SoftDeleteAndActivateUserCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
