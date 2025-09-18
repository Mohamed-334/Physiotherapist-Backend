using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace PhysiotherapistProject.Core.Features.Booking.Commands.RequestModels
{
    public class BookSessionCommandRequestModel : IRequest<Response<string>>
    {
        public int? ClinicId { get; set; }
        public string BookType { get; set; }
        public int? CourseId { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan SessionTime { get; set; }
    }
}
