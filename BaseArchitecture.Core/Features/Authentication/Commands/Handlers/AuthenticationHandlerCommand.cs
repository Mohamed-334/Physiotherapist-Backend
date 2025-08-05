using AutoMapper;
using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationHandlerCommand : ResponseHandler,
                                        IRequestHandler<SignUpCommandRequestModel, Response<string>>,
                                        IRequestHandler<ChangePasswordCommandRequestModel, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public AuthenticationHandlerCommand(IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper, IAuthenticationService authenticationService, IUserService userService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userService = userService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(SignUpCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<User>(request);
            var result = await _authenticationService.SignUpAsync(User, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure
                {
                    ErrorMessage = e.Description,
                    ErrorCode = e.Code

                }).ToList();
                throw new ValidationException(errors);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(ChangePasswordCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmail(request.Email);
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _authenticationService.ChangePasswordAsync(User, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure
                {
                    ErrorMessage = e.Description,
                    ErrorCode = e.Code
                }).ToList();
                throw new ValidationException(_stringLocalizer[AppLocalizationKeys.ChangePassFailed], errors);
            }
            return Success("");
        }
        #endregion
    }
}
