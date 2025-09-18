using BaseArchitecture.Service.Shared.Interface;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Service.ServiceInterfaces
{
    public interface ISessionService : IBaseService<Session>
    {
        Task<Session> CreateSessionName();
        Task<bool> IsSessionNameExistAsync(string SessionName, string SessionNameLocalization);
        Task<bool> IsNewSessionTimeAvailable(DateTime Date, TimeSpan Hour);
        Task<List<Session>> GetSessionsByCourseIdAsync(int CourseId);
        Task<List<Session>> GetSessionsForThisDateAsync(DateTime date);
        Task<List<Session>> GetSessionsByDateFiltersAsync(DateTime? startDate, DateTime? endDate, string? Name);
    }
}
