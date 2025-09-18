using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Sessions.Dto;
using PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;
using static BaseArchitecture.Domain.Enums.EnumExtensions;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.Handlers
{
    public class SessionQueryHandler : ResponseHandler, IRequestHandler<GetSessionByIdQueryRequestModel, Response<SessionFullDataDto>>,
                                                        IRequestHandler<GetSessionByCourseIdQueryRequestModel, Response<List<SessionDto>>>,
                                                        IRequestHandler<GetSessionListQueryRequestModel, Response<List<SessionDto>>>,
                                                        IRequestHandler<GetSessionPaginatedListQueryRequestModel, Response<PaginatedList<SessionDto>>>,
                                                        IRequestHandler<GetSessionsStatisticsQueryRequestModel, Response<SessionStatisticsDto>>,
                                                        IRequestHandler<GetTodaySessionsQueryRequestModel, Response<List<SessionFullDataDto>>>,
                                                        IRequestHandler<GetSessionsWithDateFilterQueryRequestModel, Response<List<SessionFullDataDto>>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;
        #endregion

        #region Constructor
        public SessionQueryHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  ISessionService sessionService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _sessionService = sessionService;
        }

        #endregion

        #region Methods
        public async Task<Response<SessionFullDataDto>> Handle(GetSessionByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Session = await _sessionService.GetByIdAsync(request.Id);
            if (Session == null)
                return NotFound<SessionFullDataDto>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var CourseDto = _mapper.Map<SessionFullDataDto>(Session);
            return Success(CourseDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<SessionDto>>> Handle(GetSessionListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Sessions = await _sessionService.GetAllAsync();
            if (Sessions == null)
                return NotFound<List<SessionDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var SessionsDto = _mapper.Map<List<SessionDto>>(Sessions);
            return Success(SessionsDto, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = SessionsDto.Count });

        }

        public async Task<Response<PaginatedList<SessionDto>>> Handle(GetSessionPaginatedListQueryRequestModel request, CancellationToken cancellationToken)
        {
            var PaginatedList = await _sessionService.GetPaginatedListAsync(request.PageNumber, request.PageSize);
            if (PaginatedList == null || PaginatedList.Data.Count == 0)
                return NotFound<PaginatedList<SessionDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var SessionDtoList = _mapper.Map<List<SessionDto>>(PaginatedList.Data);
            var paginatedListDto = PaginatedList<SessionDto>.Success(SessionDtoList, PaginatedList.TotalCount, PaginatedList.CurrentPage, PaginatedList.PageSize);
            return Success(paginatedListDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<SessionDto>>> Handle(GetSessionByCourseIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Sessions = await _sessionService.GetSessionsByCourseIdAsync(request.Id);
            if (Sessions == null)
                return NotFound<List<SessionDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var CourseDto = _mapper.Map<List<SessionDto>>(Sessions);
            return Success(CourseDto, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<SessionStatisticsDto>> Handle(GetSessionsStatisticsQueryRequestModel request, CancellationToken cancellationToken)
        {
            var TodayDate = DateTime.Now.Date;
            var ToDaySessions = await _sessionService.GetSessionsForThisDateAsync(TodayDate);
            if (ToDaySessions == null)
                return NotFound<SessionStatisticsDto>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var PatientsIds = ToDaySessions.Select(s => s.Course.UserId).Distinct();
            var result = new SessionStatisticsDto
            {
                TotalSessionToday = ToDaySessions.Count,
                TotalCompletedToday = ToDaySessions.Count(s => s.StatusCode == (int)SessionStatusEnum.Attended),
                TotalCancelledSessionToday = ToDaySessions.Count(s => s.StatusCode == (int)SessionStatusEnum.Cancelled),
                TotalPatientToday = PatientsIds.Count()
            };
            return Success(result, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<SessionFullDataDto>>> Handle(GetTodaySessionsQueryRequestModel request, CancellationToken cancellationToken)
        {
            var TodayDate = DateTime.Now.Date;
            var ToDaySessions = await _sessionService.GetSessionsForThisDateAsync(TodayDate);
            if (ToDaySessions == null)
                return NotFound<List<SessionFullDataDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = _mapper.Map<List<SessionFullDataDto>>(ToDaySessions);
            return Success(result, _stringLocalizer[AppLocalizationKeys.Success]);
        }

        public async Task<Response<List<SessionFullDataDto>>> Handle(GetSessionsWithDateFilterQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Sessions = await _sessionService.GetSessionsByDateFiltersAsync(request.StartDate, request.EndDate, request.Name);
            if (Sessions == null)
                return NotFound<List<SessionFullDataDto>>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var SessionsDto = _mapper.Map<List<SessionFullDataDto>>(Sessions);
            return Success(SessionsDto, _stringLocalizer[AppLocalizationKeys.Success], new { TotalCount = SessionsDto.Count });
        }
        #endregion
    }
}
