using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapistProject.Core.Features.Sessions.Commands.RequestModels;
using PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels;

namespace PhysiotherapistProject.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class SessionController : BaseControllerApp
    {
        [HttpGet(Router.SessionRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetSessionByIdQueryRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.SessionRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetSessionListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.SessionRouting.GetPaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromBody] GetSessionPaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.SessionRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSessionCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.SessionRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateSessionCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpDelete(Router.SessionRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new HardDeleteSessionCommandRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.SessionRouting.SoftDeleteAndActivate)]
        public async Task<IActionResult> SoftDeleteAndActivate([FromRoute] int id)
        {
            var response = await _mediator.Send(new SoftDeleteAndActivateSessionCommandRequestQuery(id));
            return Result(response);
        }
    }
}
