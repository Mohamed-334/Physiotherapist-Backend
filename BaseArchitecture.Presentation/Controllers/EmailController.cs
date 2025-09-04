using BaseArchitecture.Core.Features.Email.Commands.RequestModels;
using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace BaseArchitecture.Presentation.Controllers
{
    [ApiController]
    //[Authorize]
    public class EmailController : BaseControllerApp
    {
        [HttpPost(Router.EmailRouting.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommandRequestModel command)
        {
            var response = await _mediator.Send(command);
            return Result(response);
        }
    }
}
