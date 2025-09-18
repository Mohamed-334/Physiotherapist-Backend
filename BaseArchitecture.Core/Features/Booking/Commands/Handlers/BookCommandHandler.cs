using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Booking.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Booking.Commands.Handlers
{
    public class BookCommandHandler : ResponseHandler, IRequestHandler<BookSessionCommandRequestModel, Response<string>>
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ICourseService _courseService;
        private readonly ISessionService _sessionService;
        #endregion

        #region Constructor
        public BookCommandHandler(IMediator mediator, IStringLocalizer<AppLocalization> stringLocalizer, IAuthenticatedUserService authenticatedUserService, ICourseService courseService, ISessionService sessionService, IMapper mapper) : base(stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            _authenticatedUserService = authenticatedUserService;
            _courseService = courseService;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        public async Task<Response<string>> Handle(BookSessionCommandRequestModel request, CancellationToken cancellationToken)
        {
            if (request.BookType == "BookNewCourse")
            {
                var UserId = _authenticatedUserService.GetAuthenticatedUserId();
                if (UserId == 0)
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.PleaseLogin]);
                var Course = await _courseService.CreateCourseName();
                Course.UserId = UserId;
                Course.ClinicId = request.ClinicId;
                var SaveCourse = await _courseService.AddAsync(Course);
                if (SaveCourse == _stringLocalizer[AppLocalizationKeys.AddFailed])
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);

                var Session = await _sessionService.CreateSessionName();
                var SessionMapper = _mapper.Map(request, Session);
                SessionMapper.CourseId = Course.Id;
                var SaveSession = await _sessionService.AddAsync(SessionMapper);
                if (SaveSession == _stringLocalizer[AppLocalizationKeys.AddFailed])
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);

                Course.TotalSessions += 1;
                var UpdateCourse = await _courseService.EditAsync(Course);
                if (UpdateCourse == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);

                return Success<string>("");
            }
            else if (request.BookType == "BookSessionForExistCourse")
            {
                if (!request.CourseId.HasValue)
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToBook]);
                var Course = await _courseService.GetByIdAsync(request.CourseId.Value);
                var Session = await _sessionService.CreateSessionName();
                var SessionMapper = _mapper.Map(request, Session);
                SessionMapper.CourseId = Course.Id;
                var SaveSession = await _sessionService.AddAsync(SessionMapper);
                if (SaveSession == _stringLocalizer[AppLocalizationKeys.AddFailed])
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
                Course.TotalSessions += 1;
                var UpdateCourse = await _courseService.EditAsync(Course);
                if (UpdateCourse == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
                return Success<string>("");
            }
            return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToBook]);
        }

        #endregion
    }
}
