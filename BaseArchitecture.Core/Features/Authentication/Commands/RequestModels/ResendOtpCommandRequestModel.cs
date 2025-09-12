using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Authentication.Commands.RequestModels
{
    public class ResendOtpCommandRequestModel : IRequest<Response<string>>
    {
        public string? Email { get; set; }
    }
}
