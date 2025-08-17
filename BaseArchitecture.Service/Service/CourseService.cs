using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Service.Service
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        #region Feilds
        private readonly ICourseRepository _courseRepository;
        #endregion

        #region Constructor
        public CourseService(IBaseRepository<Course> baseRepository,
                             IStringLocalizer<AppLocalization> stringLocalizer,
                             ICourseRepository courseRepository) : base(baseRepository, stringLocalizer)
        {
            _courseRepository = courseRepository;
        }
        #endregion

        #region Methods
        public async Task<bool> IsCourseNameExistAsync(string courseName, string CourseNameLocalization) => await _courseRepository.IsCourseNameExistAsync(courseName, CourseNameLocalization);
        #endregion

    }
}
