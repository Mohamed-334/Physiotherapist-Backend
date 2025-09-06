using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using Microsoft.EntityFrameworkCore;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;

namespace PhysiotherapistProject.Infrastructure.Repository
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        #region Feilds
        private readonly DbSet<Clinic> _set;
        #endregion

        #region Constructor
        public ClinicRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<Clinic>();
        }
        #endregion

        #region Methods
        #endregion
    }
}
