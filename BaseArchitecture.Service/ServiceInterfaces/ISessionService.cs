using BaseArchitecture.Service.Shared.Interface;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Service.ServiceInterfaces
{
    public interface ISessionService : IBaseService<Session>
    {
        Task<bool> IsSessionNameExistAsync(string SessionName, string SessionNameLocalization);
        Task<bool> IsNewSessionTimeAvailable(DateTime Date, int Hour);
        Task<List<Session>> GetSessionsByCourseIdAsync(int CourseId);
    }
}
