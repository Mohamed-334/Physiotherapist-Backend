using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Course> CreateCourseName()
        {
            var LastCourse = await _courseRepository.GetTableAsTracking()
                .OrderBy(c => c.Id)
                .LastOrDefaultAsync();

            int LastCourseNumber = LastCourse == null ? 0 :
                                   int.Parse(new string(LastCourse.Name.Where(char.IsDigit).ToArray()));

            var Course = new Course
            {
                Name = $"Course{LastCourseNumber + 1}",
                NameLocalization = $"كورس{LastCourseNumber + 1}"
            };
            return Course;
        }
        #endregion

    }
}
