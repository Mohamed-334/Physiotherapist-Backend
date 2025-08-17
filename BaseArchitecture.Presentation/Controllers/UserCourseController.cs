using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels;
using PhysiotherapistProject.Core.Features.UserCourses.Queries.RequestModels;

namespace PhysiotherapistProject.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class UserCourseController : BaseControllerApp
    {
        [HttpGet(Router.UserCourseRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUserCourseByIdQueryRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.UserCourseRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetUserCourseListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.UserCourseRouting.GetPaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromBody] GetUserCoursePaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.UserCourseRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCourseCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.UserCourseRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCourseCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpDelete(Router.UserCourseRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new HardDeleteUserCourseCommandRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.UserCourseRouting.SoftDeleteAndActivate)]
        public async Task<IActionResult> SoftDeleteAndActivate([FromRoute] int id)
        {
            var response = await _mediator.Send(new SoftDeleteAndActivateUserCourseCommandRequestQuery(id));
            return Result(response);
        }
    }
}
