using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels;
using PhysiotherapistProject.Core.Features.Clinics.Queries.RequestModels;

namespace PhysiotherapistProject.Presentation.Controllers
{
    [ApiController]
    public class ClinicController : BaseControllerApp
    {
        [HttpGet(Router.ClinicRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetClinicByIdQueryRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.ClinicRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetClinicListQueryRequestModel());
            return Result(response);
        }
        [HttpPost(Router.ClinicRouting.GetPaginatedList)]
        public async Task<IActionResult> GetPaginatedList([FromBody] GetClinicPaginatedListQueryRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.ClinicRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddClinicCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.ClinicRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateClinicCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpDelete(Router.ClinicRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new HardDeleteClinicCommandRequestModel(id));
            return Result(response);
        }
        [HttpGet(Router.ClinicRouting.SoftDeleteAndActivate)]
        public async Task<IActionResult> SoftDeleteAndActivate([FromRoute] int id)
        {
            var response = await _mediator.Send(new SoftDeleteAndActivateClinicCommandRequestQuery(id));
            return Result(response);
        }
    }
}
