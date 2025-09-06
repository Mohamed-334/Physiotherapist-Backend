using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Clinics.Dto;

namespace PhysiotherapistProject.Core.Features.Clinics.Queries.RequestModels
{
    public class GetClinicListQueryRequestModel : IRequest<Response<List<ClinicDto>>>
    {
    }
}
