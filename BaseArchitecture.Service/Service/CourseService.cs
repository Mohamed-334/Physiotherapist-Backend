using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Service.Service
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        #region Feilds
        #endregion

        #region Constructor
        public CourseService(IBaseRepository<Course> baseRepository,
                             IStringLocalizer<AppLocalization> stringLocalizer) : base(baseRepository, stringLocalizer)
        {
        }
        #endregion

        #region Methods
        #endregion

    }
}
