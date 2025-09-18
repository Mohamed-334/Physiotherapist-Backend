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
        public override async Task<Session?> GetByIdAsync(int id)
        {
            return await _sessionRepository.GetTableAsTracking()
                                           .Include(s => s.Course)
                                           .ThenInclude(c => c.User)
                                           .Include(s => s.Course)
                                           .ThenInclude(c => c.Clinic)
                                           .FirstOrDefaultAsync(s => s.Id == id);
        }
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
        public async Task<bool> IsNewSessionTimeAvailable(DateTime Date, TimeSpan Hour)
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
        public async Task<List<Session>> GetSessionsForThisDateAsync(DateTime date)
        {
            return await _sessionRepository.GetTableNoTracking()
                                             .Include(s => s.Course)
                                             .ThenInclude(s => s.User)
                                             .Include(s => s.Course)
                                             .ThenInclude(s => s.Clinic)
                                             .Where(s => s.SessionDate.Date == date)
                                             .ToListAsync();
        }
        public async Task<List<Session>> GetSessionsByDateFiltersAsync(DateTime? startDate, DateTime? endDate, string? Name)
        {
            var Sessions = _sessionRepository.GetTableNoTracking()
                                             .Include(s => s.Course)
                                             .ThenInclude(s => s.User)
                                             .Include(s => s.Course)
                                             .ThenInclude(s => s.Clinic)
                                             .AsQueryable();
            if (startDate != DateTime.MinValue && startDate != null)
                Sessions = Sessions.Where(s => s.SessionDate.Date >= startDate);
            if (endDate != DateTime.MinValue && endDate != null)
                Sessions = Sessions.Where(s => s.SessionDate.Date <= endDate);
            if (Name != null)
                Sessions = Sessions.Where(s => s.Course.User.UserName.Contains(Name));
            return await Sessions.ToListAsync();
        }
        #endregion

    }
}
