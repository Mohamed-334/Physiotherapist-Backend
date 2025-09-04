using AutoMapper;

namespace PhysiotherapistProject.Core.Mapping.Entities.BookMapping
{
    public partial class BookMapping : Profile
    {
        public BookMapping()
        {
            MapFromBookSessionCommandRequestModelToSession();
        }
    }
}
