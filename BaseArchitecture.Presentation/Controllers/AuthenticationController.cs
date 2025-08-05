using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace BaseArchitecture.Presentation.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseControllerApp
    {
        [HttpPost(Router.AuthenticationRouting.SignUp)]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.AuthenticationRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
    }
}
