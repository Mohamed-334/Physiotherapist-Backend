using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Authentication.Commands.RequestModels
{
    public class SignInCommandRequestModel : IRequest<Response<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
