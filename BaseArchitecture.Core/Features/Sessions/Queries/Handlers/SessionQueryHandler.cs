using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.PaginatedList;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Sessions.Dto;
using PhysiotherapistProject.Core.Features.Sessions.Queries.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Courses.Queries.Handlers
{
    public class SessionQueryHandler : ResponseHandler, IRequestHandler<GetSessionByIdQueryRequestModel, Response<SessionDto>>,
                                                        IRequestHandler<GetSessionByCourseIdQueryRequestModel, Response<List<SessionDto>>>,
                                                        IRequestHandler<GetSessionListQueryRequestModel, Response<List<SessionDto>>>,
                                                        IRequestHandler<GetSessionPaginatedListQueryRequestModel, Response<PaginatedList<SessionDto>>>
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
        public async Task<Response<SessionDto>> Handle(GetSessionByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var Session = await _sessionService.GetByIdAsync(request.Id);
            if (Session == null)
                return NotFound<SessionDto>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var CourseDto = _mapper.Map<SessionDto>(Session);
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
        #endregion
    }
}
