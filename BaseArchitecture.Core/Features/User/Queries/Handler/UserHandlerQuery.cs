using AutoMapper;
using BaseArchitecture.Core.Features.ApplicationUser.Queries.DTO;
using BaseArchitecture.Core.Features.ApplicationUser.Queries.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.ApplicationUser.Queries.Handler
{
    public class UserHandlerQuery : ResponseHandler,
                                    IRequestHandler<GetUsersListQueryRequestModel, Response<List<UserFullDataDto>>>,
                                    IRequestHandler<GetUserByIdQueryRequestModel, Response<UserFullDataDto>>,
                                    IRequestHandler<GetUsersPaginatedListQueryRequestModel, Response<PaginatedList<UserFullDataDto>>>
    {

        #region Fields
        private readonly IUserService _userService;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UserHandlerQuery(IUserService userService, IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper) : base(stringLocalizer)
        {
            _userService = userService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<Response<List<UserFullDataDto>>> Handle(GetUsersListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var UserList = await _userService.GetAll();
            if (UserList == null)
                return NotFound<List<UserFullDataDto>>(_stringLocalizer[AppLocalizationKeys.UserIsNotFound]);
            var UserFullDataDtoList = _mapper.Map<List<UserFullDataDto>>(UserList);
            return Success(UserFullDataDtoList, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = UserFullDataDtoList.Count });
        }

        public async Task<Response<UserFullDataDto>> Handle(GetUserByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetById(request.UserId);
            if (User == null)
                return NotFound<UserFullDataDto>(_stringLocalizer[AppLocalizationKeys.UserIsNotFound]);
            var UserFullDataDto = _mapper.Map<UserFullDataDto>(User);
            return Success(UserFullDataDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<PaginatedList<UserFullDataDto>>> Handle(GetUsersPaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _userService.GetPaginatedList(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<UserFullDataDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var UserFullDataDtoList = _mapper.Map<List<UserFullDataDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<UserFullDataDto>.Success(UserFullDataDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }
        #endregion


    }
}
