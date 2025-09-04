using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels;
using PhysiotherapistProject.Core.Features.Courses.Queries.RequestModels;

namespace PhysiotherapistProject.Presentation.Controllers
{
    [ApiController]
    //[Authorize]
    public class CourseController : BaseControllerApp
    {
        [HttpGet(Router.CourseRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetCourseByIdQueryRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.CourseRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetCourseListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.CourseRouting.GetPaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromBody] GetCoursePaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.CourseRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddCourseCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.CourseRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpDelete(Router.CourseRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new HardDeleteCourseCommandRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.CourseRouting.SoftDeleteAndActivate)]
        public async Task<IActionResult> SoftDeleteAndActivate([FromRoute] int id)
        {
            var response = await _mediator.Send(new SoftDeleteAndActivateCourseCommandRequestQuery(id));
            return Result(response);
        }
    }
}
