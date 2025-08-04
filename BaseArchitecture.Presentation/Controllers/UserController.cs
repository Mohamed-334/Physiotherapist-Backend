using BaseArchitecture.Core.Features.ApplicationUser.Queries.RequestModels;
using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace BaseArchitecture.Presentation.Controllers
{
    [ApiController]
    public class UserController : BaseControllerApp
    {
        [HttpGet(Router.UserRouting.GetUserById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUserByIdQueryRequestModel()
            {
                UserId = id
            });
            return Result(response);
        }
        [HttpGet(Router.UserRouting.GetUsersList)]
        public async Task<IActionResult> GetUsersList()
        {
            var response = await _mediator.Send(new GetUsersListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.UserRouting.GetUsersPaginatedList)]
        public async Task<IActionResult> GetUsersPaginatedList([FromBody] GetUsersPaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
    }
}
