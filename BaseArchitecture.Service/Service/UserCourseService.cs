using BaseArchitecture.Infrastructure.Shared.Interfaces;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.Shared.BaseService;
using Microsoft.Extensions.Localization;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;
using PhysiotherapistProject.Service.ServiceInterfaces;

namespace PhysiotherapistProject.Service.Service
{
    public class UserCourseService : BaseService<UserCourse>, IUserCourseService
    {
        #region Feilds
        private readonly IUserCourseRepository _userCourseRepository;
        #endregion

        #region Constructor
        public UserCourseService(IBaseRepository<UserCourse> baseRepository,
                             IStringLocalizer<AppLocalization> stringLocalizer,
                             IUserCourseRepository userCourseRepository) : base(baseRepository, stringLocalizer)
        {
            _userCourseRepository = userCourseRepository;
        }
        #endregion

        #region Methods
        #endregion

    }
}
