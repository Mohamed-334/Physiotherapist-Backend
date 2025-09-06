using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels
{
    public class SoftDeleteAndActivateClinicCommandRequestQuery : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public SoftDeleteAndActivateClinicCommandRequestQuery(int id)
        {
            Id = id;
        }
    }
}
