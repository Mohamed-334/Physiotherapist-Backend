using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Courses.Dto;
using PhysiotherapistProject.Core.Features.Courses.Queries.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.Handlers
{
    public class CourseQueryHandler : ResponseHandler, IRequestHandler<GetCourseByIdQueryRequestModel, Response<CourseDto>>,
                                                       IRequestHandler<GetCourseListQueryRequestModel, Response<List<CourseDto>>>,
                                                       IRequestHandler<GetCoursePaginatedListQueryRequestModel, Response<PaginatedList<CourseDto>>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        #endregion

        #region Constructor
        public CourseQueryHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  ICourseService courseService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _courseService = courseService;
        }

        #endregion

        #region Methods
        public async Task<Response<CourseDto>> Handle(GetCourseByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Course = await _courseService.GetByIdAsync(request.Id);
            if (Course == null)
                return NotFound<CourseDto>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var CourseDto = _mapper.Map<CourseDto>(Course);
            return Success(CourseDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<CourseDto>>> Handle(GetCourseListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Courses = await _courseService.GetAllAsync();
            if (Courses == null)
                return NotFound<List<CourseDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var CoursesDto = _mapper.Map<List<CourseDto>>(Courses);
            return Success(CoursesDto, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = CoursesDto.Count });

        }

        public async Task<Response<PaginatedList<CourseDto>>> Handle(GetCoursePaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _courseService.GetPaginatedListAsync(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<CourseDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var RoleFullDataDtoList = _mapper.Map<List<CourseDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<CourseDto>.Success(RoleFullDataDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }
        #endregion
    }
}
