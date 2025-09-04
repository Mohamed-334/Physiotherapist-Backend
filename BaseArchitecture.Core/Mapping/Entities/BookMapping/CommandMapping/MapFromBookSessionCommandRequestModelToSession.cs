using BaseArchitecture.Core.Mapping.Shared;
using PhysiotherapistProject.Core.Features.Booking.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Core.Mapping.Entities.BookMapping
{
    public partial class BookMapping
    {
        public void MapFromBookSessionCommandRequestModelToSession()
        {
            CreateMap<BookSessionCommandRequestModel, Session>()
                .AfterMap<MetaMappingDataBasedOnDestination<BookSessionCommandRequestModel, Session>>();
        }
    }
}
