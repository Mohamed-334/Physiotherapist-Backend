using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels
{
    public class HardDeleteClinicCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public HardDeleteClinicCommandRequestModel(int id)
        {
            Id = id;
        }
    }
}
