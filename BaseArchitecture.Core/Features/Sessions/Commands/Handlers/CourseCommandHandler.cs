using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Sessions.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Sessions.Commands.Handlers
{
    public class SessionCommandHandler : ResponseHandler, IRequestHandler<AddSessionCommandRequestModel, Response<string>>,
                                                         IRequestHandler<UpdateSessionCommandRequestModel, Response<string>>,
                                                         IRequestHandler<HardDeleteSessionCommandRequestModel, Response<string>>,
                                                         IRequestHandler<SoftDeleteAndActivateSessionCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        #endregion

        #region Constructor
        public SessionCommandHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  ISessionService sessionService,
                                  IAuthenticatedUserService authenticatedUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _sessionService = sessionService;
            _authenticatedUserService = authenticatedUserService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddSessionCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Session = _mapper.Map<Session>(request);
            var result = await _sessionService.AddAsync(Session);
            if (result == _stringLocalizer[AppLocalizationKeys.AddFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateSessionCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Session = await _sessionService.GetByIdAsync(request.Id);
            if (Session == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var SessionMapper = _mapper.Map(request, Session);
            var result = await _sessionService.EditAsync(SessionMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(HardDeleteSessionCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Session = await _sessionService.GetByIdAsync(request.Id);
            if (Session == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _sessionService.HardDeleteAsync(Session);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(SoftDeleteAndActivateSessionCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var Session = await _sessionService.GetByIdAsync(request.Id);
            if (Session == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            Session.IsDeleted = !(Session.IsDeleted);
            Session.DeletionDate = DateTime.UtcNow;
            Session.DeleterName = _authenticatedUserService.GetAuthenticatedUserName();
            var result = await _sessionService.EditAsync(Session);

            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            if (Session.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }
        #endregion

    }
}
