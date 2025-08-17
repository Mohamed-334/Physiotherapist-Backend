using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.UserCourses.Dto;
using PhysiotherapistProject.Core.Features.UserCourses.Queries.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.UserCourses.Queries.Handlers
{
    public class UserCourseQueryHandler : ResponseHandler, IRequestHandler<GetUserCourseByIdQueryRequestModel, Response<UserCourseDto>>,
                                                       IRequestHandler<GetUserCourseListQueryRequestModel, Response<List<UserCourseDto>>>,
                                                       IRequestHandler<GetUserCoursePaginatedListQueryRequestModel, Response<PaginatedList<UserCourseDto>>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IUserCourseService _userCourseService;
        #endregion

        #region Constructor
        public UserCourseQueryHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  IUserCourseService userCourseService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userCourseService = userCourseService;
        }

        #endregion

        #region Methods
        public async Task<Response<UserCourseDto>> Handle(GetUserCourseByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var UserCourse = await _userCourseService.GetByIdAsync(request.Id);
            if (UserCourse == null)
                return NotFound<UserCourseDto>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var CourseDto = _mapper.Map<UserCourseDto>(UserCourse);
            return Success(CourseDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<UserCourseDto>>> Handle(GetUserCourseListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var UserCourses = await _userCourseService.GetAllAsync();
            if (UserCourses == null)
                return NotFound<List<UserCourseDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var UserCoursesDto = _mapper.Map<List<UserCourseDto>>(UserCourses);
            return Success(UserCoursesDto, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = UserCoursesDto.Count });

        }

        public async Task<Response<PaginatedList<UserCourseDto>>> Handle(GetUserCoursePaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _userCourseService.GetPaginatedListAsync(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<UserCourseDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var UserCourseDtoList = _mapper.Map<List<UserCourseDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<UserCourseDto>.Success(UserCourseDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }
        #endregion
    }
}
