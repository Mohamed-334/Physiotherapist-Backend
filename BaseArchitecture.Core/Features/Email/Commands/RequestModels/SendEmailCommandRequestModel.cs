using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Email.Commands.RequestModels
{
    public class SendEmailCommandRequestModel : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
