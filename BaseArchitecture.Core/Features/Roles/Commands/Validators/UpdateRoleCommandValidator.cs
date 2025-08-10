using BaseArchitecture.Core.Features.Roles.Commands.RequestModels;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Roles.Commands.Validators
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommandRequestModel>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IRoleService _roleService;
        #endregion

        #region Constructor
        public UpdateRoleCommandValidator(IStringLocalizer<AppLocalization> stringLocalizer, IRoleService roleService)
        {
            _stringLocalizer = stringLocalizer;
            _roleService = roleService;
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
        }
        public void ApplyCustomSignUpCommandValidation()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (RoleName, cancellation) => !(await _roleService.IsRoleNameExist(RoleName)))
                .WithMessage(_stringLocalizer[AppLocalizationKeys.UserNameIsExist]);
        }
        #endregion
    }

}
