using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using PhysiotherapistProject.Core.Features.Clinics.Dto;
using PhysiotherapistProject.Core.Features.Courses.Dto;

namespace PhysiotherapistProject.Core.Features.Clinics.Queries.RequestModels
{
    public class GetClinicPaginatedListQueryRequestModel : IRequest<Response<PaginatedList<ClinicDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetClinicPaginatedListQueryRequestModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
