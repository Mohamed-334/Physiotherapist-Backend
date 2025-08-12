using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.Authentication.Commands.RequestModels
{
    public class ResetPasswordOtpVerificationCommandRequestModel : OtpVerificationCommandRequestModel, IRequest<Response<string>>
    {
    }
}
