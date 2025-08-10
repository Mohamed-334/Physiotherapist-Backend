using AutoMapper;
using BaseArchitecture.Core.Features.Roles.Commands.RequestModels;
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
    public class RoleHandlerCommand : ResponseHandler,
                                        IRequestHandler<AddRoleCommandRequestModel, Response<string>>,
                                        IRequestHandler<UpdateRoleCommandRequestModel, Response<string>>,
                                        IRequestHandler<DeleteRoleCommandRequestModel, Response<string>>,
                                        IRequestHandler<SoftDeleteAndActivateUserCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly IRoleService _roleService;
        #endregion

        #region Constructor
        public RoleHandlerCommand(IStringLocalizer<AppLocalization> stringLocalizer, IMapper mapper, IAuthenticationService authenticationService, IRoleService roleService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _authenticationService = authenticationService;
            _roleService = roleService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddRoleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Role = _mapper.Map<Role>(request);
            var result = await _roleService.AddRole(Role);
            if (!result.Succeeded)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateRoleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetById(request.Id);
            if (role == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var roleMapper = _mapper.Map(request, role);
            var result = await _roleService.EditAsync(roleMapper);
            if (!result.Succeeded)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetById(request.Id);
            if (role == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _roleService.HardDeleteAsync(role);
            if (!result.Succeeded)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.FailedToRemoveOldRoles]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }
        public async Task<Response<string>> Handle(SoftDeleteAndActivateUserCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var user = await _roleService.GetById(request.Id);
            if (user == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            user.IsDeleted = !(user.IsDeleted);
            var result = await _roleService.EditAsync(user);

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
