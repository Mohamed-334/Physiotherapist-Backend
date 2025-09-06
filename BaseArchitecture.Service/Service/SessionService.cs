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
    public class SessionService : BaseService<Session>, ISessionService
    {
        #region Feilds
        private readonly ISessionRepository _sessionRepository;
        #endregion

        #region Constructor
        public SessionService(IBaseRepository<Session> baseRepository,
                             IStringLocalizer<AppLocalization> stringLocalizer,
                             ISessionRepository sessionRepository) : base(baseRepository, stringLocalizer)
        {
            _sessionRepository = sessionRepository;
        }
        #endregion

        #region Methods
        public async Task<Session> CreateSessionName()
        {
            var LastSession = await _sessionRepository.GetTableAsTracking()
                .OrderBy(c => c.Id)
                .LastOrDefaultAsync();

            int LastSessionNumber = LastSession == null ? 0 :
                                   int.Parse(new string(LastSession?.Name?.Where(char.IsDigit).ToArray()));

            var Session = new Session
            {
                Name = $"Session{LastSessionNumber + 1}",
                NameLocalization = $"جلسة{LastSessionNumber + 1}"
            };
            return Session;
        }
        public async Task<bool> IsSessionNameExistAsync(string SessionName, string SessionNameLocalization) => await _sessionRepository.IsSessionNameExistAsync(SessionName, SessionNameLocalization);
        public async Task<bool> IsNewSessionTimeAvailable(DateTime Date, int Hour)
        {
            var Sessions = await _sessionRepository.GetTableNoTracking()
                                            .Where(s => s.SessionDate == Date && s.SessionTime == Hour)
                                            .CountAsync();
            return Sessions < 10;
        }
        public async Task<List<Session>> GetSessionsByCourseIdAsync(int CourseId)
        {
            return await _sessionRepository.GetTableNoTracking()
                .Where(s => s.CourseId == CourseId)
                .ToListAsync();
        }
        #endregion

    }
}
