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
    public class AuthenticationHandler : ResponseHandler,
                                        IRequestHandler<SignUpCommandRequestModel, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructor
        public AuthenticationHandler(IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper, IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authenticationService = authenticationService;
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
        #endregion
    }
}
