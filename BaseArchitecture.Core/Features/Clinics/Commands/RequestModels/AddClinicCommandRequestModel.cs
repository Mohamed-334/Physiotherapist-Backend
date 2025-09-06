using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels
{
    public class AddClinicCommandRequestModel : IRequest<Response<string>>
    {
        public string? Name { get; set; }
        public string? NameLocalization { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int? ClinicMangerId { get; set; }
        public string? ClinicImage { get; set; }

        public AddClinicCommandRequestModel(string? name, string? nameLocalization, int startHour, int endHour, int? clinicMangerId, string? clinicImage)
        {
            Name = name;
            NameLocalization = nameLocalization;
            StartHour = startHour;
            EndHour = endHour;
            ClinicMangerId = clinicMangerId;
            ClinicImage = clinicImage;
        }
    }
}
