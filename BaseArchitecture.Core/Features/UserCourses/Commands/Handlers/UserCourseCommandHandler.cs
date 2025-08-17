using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.UserCourses.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.UserCourses.Commands.Handlers
{
    public class UserCourseCommandHandler : ResponseHandler, IRequestHandler<AddUserCourseCommandRequestModel, Response<string>>,
                                                         IRequestHandler<UpdateUserCourseCommandRequestModel, Response<string>>,
                                                         IRequestHandler<HardDeleteUserCourseCommandRequestModel, Response<string>>,
                                                         IRequestHandler<SoftDeleteAndActivateUserCourseCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IUserCourseService _userCourseService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        #endregion

        #region Constructor
        public UserCourseCommandHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  IUserCourseService userCourseService,
                                  IAuthenticatedUserService authenticatedUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userCourseService = userCourseService;
            _authenticatedUserService = authenticatedUserService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddUserCourseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var UserCourse = _mapper.Map<UserCourse>(request);
            var result = await _userCourseService.AddAsync(UserCourse);
            if (result == _stringLocalizer[AppLocalizationKeys.AddFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateUserCourseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var UserCourse = await _userCourseService.GetByIdAsync(request.Id);
            if (UserCourse == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var UserCourseMapper = _mapper.Map(request, UserCourse);
            var result = await _userCourseService.EditAsync(UserCourseMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(HardDeleteUserCourseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var UserCourse = await _userCourseService.GetByIdAsync(request.Id);
            if (UserCourse == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _userCourseService.HardDeleteAsync(UserCourse);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(SoftDeleteAndActivateUserCourseCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var UserCourse = await _userCourseService.GetByIdAsync(request.Id);
            if (UserCourse == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            UserCourse.IsDeleted = !(UserCourse.IsDeleted);
            UserCourse.DeletionDate = DateTime.UtcNow;
            UserCourse.DeleterName = _authenticatedUserService.GetAuthenticatedUserName();
            var result = await _userCourseService.EditAsync(UserCourse);

            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            if (UserCourse.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }
        #endregion

    }
}
