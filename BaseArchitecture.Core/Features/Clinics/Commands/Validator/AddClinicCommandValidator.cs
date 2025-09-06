using BaseArchitecture.Infrastructure.Shared.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Clinics.Commands.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Clinics.Commands.Validator
{
    public class AddClinicCommandValidator : AbstractValidator<AddClinicCommandRequestModel>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IClinicService _clinicService;
        #endregion

        #region Constructor
        public AddClinicCommandValidator(IStringLocalizer<AppLocalization> stringLocalizer, IClinicService clinicService)
        {
            _stringLocalizer = stringLocalizer;
            _clinicService = clinicService;
            ApplySignUpCommandValidation();
            ApplyCustomSignUpCommandValidation();
        }
        #endregion

        #region Methods

        public void ApplySignUpCommandValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.NameLocalization)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.StartHour)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.EndHour)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
        }
        public void ApplyCustomSignUpCommandValidation()
        {
        }
        #endregion
    }

}

