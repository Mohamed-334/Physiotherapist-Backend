using AutoMapper;
using BaseArchitecture.Core.Shared.Models;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using MediatR;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Core.Features.Courses.Commands.RequestModels;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Core.Features.Courses.Commands.Handlers
{
    public class CourseCommandHandler : ResponseHandler, IRequestHandler<AddCourseCommandRequestModel, Response<string>>,
                                                         IRequestHandler<UpdateCourseCommandRequestModel, Response<string>>,
                                                         IRequestHandler<HardDeleteCourseCommandRequestModel, Response<string>>,
                                                         IRequestHandler<SoftDeleteAndActivateCourseCommandRequestQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        #endregion

        #region Constructor
        public CourseCommandHandler(IStringLocalizer<AppLocalization> stringLocalizer,
                                  IMapper mapper,
                                  ICourseService courseService,
                                  IAuthenticatedUserService authenticatedUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _courseService = courseService;
            _authenticatedUserService = authenticatedUserService;
        }
        #endregion

        #region Methods
        public async Task<Response<string>> Handle(AddCourseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var Course = _mapper.Map<Course>(request);
            var result = await _courseService.AddAsync(Course);
            if (result == _stringLocalizer[AppLocalizationKeys.AddFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.AddFailed]);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateCourseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetByIdAsync(request.Id);
            if (course == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);

            var courseMapper = _mapper.Map(request, course);
            var result = await _courseService.EditAsync(courseMapper);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.UpdateFailed]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Updated]);
        }

        public async Task<Response<string>> Handle(HardDeleteCourseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetByIdAsync(request.Id);
            if (course == null)
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            var result = await _courseService.HardDeleteAsync(course);
            if (result == _stringLocalizer[AppLocalizationKeys.UpdateFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(SoftDeleteAndActivateCourseCommandRequestQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetByIdAsync(request.Id);
            if (course == null)
                return NotFound<string>(_stringLocalizer[AppLocalizationKeys.NotFound]);
            course.IsDeleted = !(course.IsDeleted);
            course.DeletionDate = DateTime.UtcNow;
            course.DeleterName = _authenticatedUserService.GetAuthenticatedUserName();
            var result = await _courseService.EditAsync(course);

            if (result == _stringLocalizer[AppLocalizationKeys.DeletedFailed])
                return BadRequest<string>(_stringLocalizer[AppLocalizationKeys.DeletedFailed]);
            if (course.IsDeleted)
                return Deleted<string>(_stringLocalizer[AppLocalizationKeys.Deleted]);
            return Success<string>(_stringLocalizer[AppLocalizationKeys.Activated]);
        }
        #endregion

    }
}
