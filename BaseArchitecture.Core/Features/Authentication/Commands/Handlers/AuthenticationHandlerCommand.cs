using AutoMapper;
using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationHandlerCommand : ResponseHandler,
                                        IRequestHandler<SignUpCommandRequestModel, Response<string>>,
                                        IRequestHandler<SignUpWithNoVerifyCommandRequestModel, Response<string>>,
                                        IRequestHandler<ChangePasswordCommandRequestModel, Response<string>>,
                                        IRequestHandler<SignInCommandRequestModel, Response<string>>,
                                        IRequestHandler<OtpVerificationCommandRequestModel, Response<string>>,
                                        IRequestHandler<ResetPasswordRequestCommandRequestModel, Response<string>>,
                                        IRequestHandler<ResetPasswordOtpVerificationCommandRequestModel, Response<string>>,
                                        IRequestHandler<ResetPasswordCommandRequestModel, Response<string>>,
                                        IRequestHandler<ResendOtpCommandRequestModel, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public AuthenticationHandlerCommand(IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper, IAuthenticationService authenticationService, IUserService userService, IEmailService emailService, IFileService fileService, IHttpContextAccessor httpContextAccessor) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _userService = userService;
            _emailService = emailService;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(SignUpCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<User>(request);
            var ImageUploadingResult = await _fileService.UploadImage("Users", request.ProfileImageFile);
            if (ImageUploadingResult == _stringLocalizer[AppLocalizationKeys.FailedToUploadImage])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToUploadImage]);

            if (ImageUploadingResult == _stringLocalizer[AppLocalizationKeys.NoImage])
                User.ProfileImage = null;
            else
                User.ProfileImage = ImageUploadingResult;
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
            if (await _userService.IsUserInRoleAsync(User, request.Role))
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.RoleIsUsed]);
            IdentityResult RoleResult;
            if (request.Role == null)
                RoleResult = await _userService.AddUserToRoleAsync(User, "Patient");
            else
                RoleResult = await _userService.AddUserToRoleAsync(User, request.Role);

            if (!RoleResult.Succeeded)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToAddNewRoles]);

            var otp = await _authenticationService.GenerateOtpAsync(User);
            var message = $"Hello {User.UserName},\n\n" +
                $"Your OTP confirmation code is: {otp}\n\n" +
                "This code will expire in 5 minutes. If you did not request it, please ignore this email.\n\n" +
                "Best regards,\nYour App Team";
            var emailResult = await _emailService.SendEmailAsync(User.Email, message, "Otp Confirmation");

            if (string.IsNullOrEmpty(otp) || emailResult == _stringLocalizer[AppLocalizationKeys.SendEmailFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToGenerateOtp]);

            User.TwoFactorEnabled = true;
            await _userService.EditAsync(User);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.OtpGenerated]);
        }

        public async Task<Response<string>> Handle(SignUpWithNoVerifyCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<User>(request);
            var ImageUploadingResult = await _fileService.UploadImage("Users", request.ProfileImageFile);
            if (ImageUploadingResult == _stringLocalizer[AppLocalizationKeys.FailedToUploadImage])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToUploadImage]);

            if (ImageUploadingResult == _stringLocalizer[AppLocalizationKeys.NoImage])
                User.ProfileImage = null;
            else
                User.ProfileImage = ImageUploadingResult;
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
            if (await _userService.IsUserInRoleAsync(User, request.Role))
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.RoleIsUsed]);
            IdentityResult RoleResult;
            if (request.Role == null)
                RoleResult = await _userService.AddUserToRoleAsync(User, "Patient");
            else
                RoleResult = await _userService.AddUserToRoleAsync(User, request.Role);

            if (!RoleResult.Succeeded)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToAddNewRoles]);


            return Success<string>(_stringLocalizer[AppLocalizationKeys.Created]);
        }

        public async Task<Response<string>> Handle(ChangePasswordCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmailAsync(request.Email);
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
        public async Task<Response<string>> Handle(SignInCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmailAsync(request.Email);
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var PasswordCheck = await _authenticationService.CheckSignInPasswordAsync(User, request.Password, false);
            if (!PasswordCheck.Succeeded)
                return Unauthorized<string>(_stringLocalizer[AppLocalizationKeys.PasswordNotCorrect]);

            //if (!User.TwoFactorEnabled)
            //    return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.EmailNotConfirmed]);

            var AccessToken = await _authenticationService.GenerateTokenAsync(User);
            return Success(AccessToken.Item2);
        }

        public async Task<Response<string>> Handle(OtpVerificationCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmailAsync(request.Email);
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _authenticationService.VerifyOtpAsync(User, request.OtpCode);
            if (!result)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.FailedToVerifyOtp]);
            var AccessToken = await _authenticationService.GenerateTokenAsync(User);

            return Success(AccessToken.Item2);
        }

        public async Task<Response<string>> Handle(ResetPasswordRequestCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmailAsync(request.Email);
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            if (!User.TwoFactorEnabled)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.EmailNotConfirmed]);

            var otp = await _authenticationService.GenerateOtpAsync(User);

            var emailMessage =
                                $"Hello {User.UserName},\n\n" +
                                $"We received a request to reset your password.\n" +
                                $"Your One-Time Password (OTP) is: {otp}\n\n" +
                                $"This OTP will expire in 5 minutes.\n" +
                                $"If you did not request this, please ignore this message.\n\n" +
                                $"Best regards,\n" +
                                $" Team";

            var result = await _emailService.SendEmailAsync(User.Email!, emailMessage, "Resend OTP");
            if (result == _stringLocalizer[AppLocalizationKeys.SendEmailFailed] || string.IsNullOrEmpty(otp))
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToGenerateOtp]);

            return Success<string>(_stringLocalizer[AppLocalizationKeys.OtpGenerated]);

        }

        public async Task<Response<string>> Handle(ResetPasswordOtpVerificationCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmailAsync(request.Email);
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _authenticationService.VerifyOtpAsync(User, request.OtpCode);
            if (!result)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.FailedToVerifyOtp]);

            return Success<string>(_stringLocalizer[AppLocalizationKeys.OtpVerified]);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommandRequestModel request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmailAsync(request.Email);
            if (user == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _authenticationService.ResetPasswordAsync(user, request.Password);
            if (!result.Succeeded)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.ChangePassFailed]);
            var token = await _authenticationService.GenerateTokenAsync(user);
            return Success<string>(token.Item2);
        }

        public async Task<Response<string>> Handle(ResendOtpCommandRequestModel request, CancellationToken cancellationToken)
        {
            var User = await _userService.GetUserByEmailAsync(request.Email!);
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var otp = await _authenticationService.GenerateOtpAsync(User);

            var emailMessage = $"Hello {User.UserName},\n\n" +
               $"Your OTP confirmation code is: {otp}\n\n" +
               "This code will expire in 5 minutes. If you did not request it, please ignore this email.\n\n" +
               "Best regards,\nYour App Team";

            var result = await _emailService.SendEmailAsync(User.Email!, emailMessage, "Reset OTP");
            if (result == _stringLocalizer[AppLocalizationKeys.SendEmailFailed] || string.IsNullOrEmpty(otp))
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToGenerateOtp]);

            return Success<string>(_stringLocalizer[AppLocalizationKeys.OtpGenerated]);
        }
        #endregion
    }
}
