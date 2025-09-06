using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels
{
    public class UpdateClinicCommandRequestModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameLocalization { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int? ClinicMangerId { get; set; }
        public string? ClinicImage { get; set; }
    }
}
