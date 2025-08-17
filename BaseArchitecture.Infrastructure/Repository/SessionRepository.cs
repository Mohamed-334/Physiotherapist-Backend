using BaseArchitecture.Infrastructure.Context;
using BaseArchitecture.Infrastructure.Shared.BaseRepository;
using Microsoft.EntityFrameworkCore;
using PhysiotherapistProject.Domain.Entities;
using PhysiotherapistProject.Infrastructure.RepositoryInterfaces;

namespace PhysiotherapistProject.Infrastructure.Repository
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        #region Feilds
        private readonly DbSet<Session> _set;
        #endregion

        #region Constructor
        public SessionRepository(AppDbContext context) : base(context)
        {
            _set = context.Set<Session>();
        }
        #endregion

        #region Methods
        public async Task<bool> IsSessionNameExistAsync(string SessionName, string SessionNameLocalization) => await _set.AnyAsync(x => x.Name == SessionName || x.NameLocalization == SessionNameLocalization);
        #endregion
    }
}
