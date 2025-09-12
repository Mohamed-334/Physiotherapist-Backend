﻿using BaseArchitecture.Core.Features.Authentication.Commands.RequestModels;
using BaseArchitecture.Domain.Meta;
using BaseArchitecture.Presentation.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace BaseArchitecture.Presentation.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseControllerApp
    {
        [HttpPost(Router.AuthenticationRouting.SignUp)]
        public async Task<IActionResult> SignUp([FromForm] SignUpCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.AuthenticationRouting.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.AuthenticationRouting.ResendOtp)]
        public async Task<IActionResult> ResendOtp([FromBody] ResendOtpCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.AuthenticationRouting.VerifyRegistrationOtp)]
        public async Task<IActionResult> VerifyRegistrationOtp([FromForm] OtpVerificationCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.AuthenticationRouting.VerifyResetPasswordOtp)]
        public async Task<IActionResult> VerifyResetPasswordOtp([FromForm] ResetPasswordOtpVerificationCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPut(Router.AuthenticationRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.AuthenticationRouting.ResetPasswordRequest)]
        public async Task<IActionResult> ResetPasswordRequest([FromForm] ResetPasswordRequestCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
        [HttpPost(Router.AuthenticationRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommandRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Result(response);
        }
    }
}
