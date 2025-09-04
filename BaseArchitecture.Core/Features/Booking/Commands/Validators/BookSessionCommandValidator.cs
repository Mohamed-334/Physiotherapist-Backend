using BaseArchitecture.Infrastructure.Shared.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Booking.Commands.RequestModels;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Courses.Commands.Validator
{
    public class BookSessionCommandValidator : AbstractValidator<BookSessionCommandRequestModel>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly ISessionService _sessionService;
        #endregion

        #region Constructor
        public BookSessionCommandValidator(IStringLocalizer<AppLocalization> stringLocalizer, ISessionService sessionService)
        {
            _stringLocalizer = stringLocalizer;
            _sessionService = sessionService;
            ApplySignUpCommandValidation();
            ApplyCustomSignUpCommandValidation();
        }
        #endregion

        #region Methods

        public void ApplySignUpCommandValidation()
        {
            RuleFor(x => x.BookType)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.SessionTime)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
            RuleFor(x => x.SessionDate)
                .NotEmpty().WithMessage(_stringLocalizer[AppLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[AppLocalizationKeys.Required]);
        }
        public void ApplyCustomSignUpCommandValidation()
        {
            RuleFor(x => x.SessionTime)
                .MustAsync(async (model, SessionTime, cancellation) => !(await _sessionService.IsNewSessionTimeAvailable(model.SessionDate, SessionTime)))
                .WithMessage(_stringLocalizer[AppLocalizationKeys.InvalidBookingDate]);
        }
        #endregion
    }

}

