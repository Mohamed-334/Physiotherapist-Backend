using BaseArchitecture.Core.Features.ApplicationUser.DTO;
using BaseArchitecture.Core.Shared.Models;
using MediatR;

namespace BaseArchitecture.Core.Features.ApplicationUser.Queries.RequestModels
{
    public class GetUsersListQueryRequestModel : IRequest<Response<List<UserFullDataDto>>>
    {
    }
}
