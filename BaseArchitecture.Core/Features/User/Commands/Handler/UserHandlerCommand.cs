using AutoMapper;
using BaseArchitecture.Core.Features.ApplicationUser.Commands.RequestModels;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Core.Features.ApplicationUser.Commands.Handler
{
    public class UserHandlerCommand : ResponseHandler,
                                      IRequestHandler<UpdateUserCommandRequestQuery, Response<string>>,
                                      IRequestHandler<DeleteUserCommandRequestQuery, Response<string>>,
                                      IRequestHandler<SoftDeleteAndActivateUserCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UserHandlerCommand(IMapper mapper, IStringLocalizer<AppLocalization> stringLocalizer, UserManager<User> userManager, IUserService userService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _userService = userService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(UpdateUserCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var OldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (OldUser == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var NewUser = _mapper.Map(request, OldUser);
            var result = await _userService.EditAsync(NewUser);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure
                {
                    ErrorMessage = e.Description,
                    ErrorCode = e.Code

                }).ToList();
                throw new ValidationException(_stringLocalizer[AppLocalizationKeys.UpdateFailed], errors);
            }
            return Success("");

        }

        public async Task<Response<string>> Handle(DeleteUserCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var result = await _userService.HardDeleteAsync(User);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure
                {
                    ErrorMessage = e.Description,
                    ErrorCode = e.Code

                }).ToList();
                throw new ValidationException(_stringLocalizer[AppLocalizationKeys.DeletedFailed], errors);
            }

            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(SoftDeleteAndActivateUserCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            user.IsDeleted = !(user.IsDeleted);
            var result = await _userService.EditAsync(user);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure
                {
                    ErrorMessage = e.Description,
                    ErrorCode = e.Code

                }).ToList();
                throw new ValidationException(_stringLocalizer[AppLocalizationKeys.DeletedFailed], errors);
            }
            if (user.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }

        #endregion
    }
}

