using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Roles.Commands.RequestModels
{
    public class UpdateRoleCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameLocalization { get; set; }
    }
}
