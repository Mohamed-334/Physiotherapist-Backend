using BaseArchitecture.Core.Shared.Models;
using MediatR;
using PhysiotherapistProject.Core.Features.Clinics.Dto;

namespace PhysiotherapistProject.Core.Features.Clinics.Queries.RequestModels
{
    public class GetClinicByIdQueryRequestModel : IRequest<Response<ClinicDto>>
    {
        public int Id { get; set; }
        public GetClinicByIdQueryRequestModel(int id)
        {
            Id = id;
        }
    }
}
