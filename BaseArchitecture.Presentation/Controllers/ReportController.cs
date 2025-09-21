using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapistProject.Core.Features.Reports.Commands.RequestModels;

namespace PhysiotherapistProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseControllerApp
    {

        [HttpPost(Router.ReportRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddReportCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
    }
}
