using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using Microsoft.EntityFrameworkCore;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;

namespace PhysiotherapistProject.Infrastructure.Repository
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        #region Feilds
        private readonly DbSet<Report> _set;
        #endregion

        #region Constructor
        public ReportRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<Report>();
        }
        #endregion

        #region Methods
        #endregion
    }
}
