using BaseArchitecture.Infrastructure.Shared.Interfaces;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Infrastructure.RepositoryInterfaces
{
    public interface ISessionRepository : IBaseRepository<Session>
    {
        Task<bool> IsSessionNameExistAsync(string SessionName, string SessionNameLocalization);
    }
}
