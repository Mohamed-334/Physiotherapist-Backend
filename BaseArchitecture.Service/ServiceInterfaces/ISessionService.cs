using BaseArchitecture.Service.Shared.Interface;
using PhysiotherapistProject.Domain.Entities;

namespace PhysiotherapistProject.Service.ServiceInterfaces
{
    public interface ISessionService : IBaseService<Session>
    {
        Task<bool> IsSessionNameExistAsync(string SessionName, string SessionNameLocalization);
    }
}
