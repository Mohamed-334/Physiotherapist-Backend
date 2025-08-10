using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Service.Shared.PaginatedList;
using Microsoft.AspNetCore.Identity;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IRoleService
    {
        Task<List<Role>?> GetAll();
        Task<Role?> GetById(int id);
        Task<IdentityResult> AddRole(Role role);
        Task<IdentityResult> EditAsync(Role entity);
        Task<IdentityResult> HardDeleteAsync(Role entity);
        Task<PaginatedList<Role>> GetPaginatedList(int pageNumber = 1, int pageSize = 10);
        Task<bool> IsRoleNameExist(string email);
        Task<bool> RoleIsUsed(int roleId);
    }
}
