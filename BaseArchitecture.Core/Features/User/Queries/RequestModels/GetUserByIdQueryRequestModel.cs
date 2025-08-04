using BaseArchitecture.Core.Features.ApplicationUser.Queries.DTO;
using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.ApplicationUser.Queries.RequestModels
{
    public class GetUserByIdQueryRequestModel : IRequest<Response<UserFullDataDto>>
    {
        public int UserId { get; set; }

    }
}
