using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using Microsoft.EntityFrameworkCore;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;

namespace PhysiotherapistProject.Infrastructure.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        #region Feilds
        private readonly DbSet<Course> _set;
        #endregion

        #region Constructor
        public CourseRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<Course>();
        }
        #endregion
    }
}
