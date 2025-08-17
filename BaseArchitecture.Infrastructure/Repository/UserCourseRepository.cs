using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using Microsoft.EntityFrameworkCore;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;

namespace PhysiotherapistProject.Infrastructure.Repository
{
    public class UserCourseRepository : BaseRepository<UserCourse>, IUserCourseRepository
    {
        #region Feilds
        private readonly DbSet<UserCourse> _set;
        #endregion

        #region Constructor
        public UserCourseRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<UserCourse>();
        }
        #endregion

        #region Methods
        #endregion
    }
}
