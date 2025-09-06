using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Clinics.Commands.Handlers
{
    public class ClinicCommandHandler : ResponseHandler, IRequestHandler<AddClinicCommandRequestModel, Response<string>>,
                                                         IRequestHandler<UpdateClinicCommandRequestModel, Response<string>>,
                                                         IRequestHandler<HardDeleteClinicCommandRequestModel, Response<string>>,
                                                         IRequestHandler<SoftDeleteAndActivateClinicCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IClinicService _clinicService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        #endregion

        #region Constructor
        public ClinicCommandHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  IClinicService clinicService,
                                  IAuthenticatedUserService authenticatedUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _clinicService = clinicService;
            _authenticatedUserService = authenticatedUserService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddClinicCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Clinic = _mapper.Map<Clinic>(request);
            var result = await _clinicService.AddAsync(Clinic);
            if (result == _stringLocalizer[AppLocalizationKeys.AddFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateClinicCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Clinic = await _clinicService.GetByIdAsync(request.Id);
            if (Clinic == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var ClinicMapper = _mapper.Map(request, Clinic);
            var result = await _clinicService.EditAsync(ClinicMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(HardDeleteClinicCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Clinic = await _clinicService.GetByIdAsync(request.Id);
            if (Clinic == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _clinicService.HardDeleteAsync(Clinic);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(SoftDeleteAndActivateClinicCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var Clinic = await _clinicService.GetByIdAsync(request.Id);
            if (Clinic == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            Clinic.IsDeleted = !(Clinic.IsDeleted);
            Clinic.DeletionDate = DateTime.UtcNow;
            Clinic.DeleterName = _authenticatedUserService.GetAuthenticatedUserName();
            var result = await _clinicService.EditAsync(Clinic);

            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            if (Clinic.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }
        #endregion

    }
}
