using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapistProject.Core.Features.Booking.Commands.RequestModels;

namespace PhysiotherapistProject.Presentation.Controllers
{
    [ApiController]
    public class BookingController : BaseControllerApp
    {
        [HttpPost(Router.BookingRouting.BookSession)]
        public async Task<IActionResult> BookSession([FromForm] BookSessionCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
    }
}
