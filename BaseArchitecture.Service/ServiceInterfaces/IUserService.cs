using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Service.Shared.PaginatedList;
using Microsoft.AspNetCore.Identity;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<User>?> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<List<string>> GetUserRolesAsync(User user);
        Task<IdentityResult> AddUserToRoleAsync(User user, string role);
        Task<bool> IsUserInRoleAsync(User user, string role);
        Task<IdentityResult> EditAsync(User entity);
        Task<IdentityResult> HardDeleteAsync(User entity);
        Task<PaginatedList<User>> GetPaginatedListAsync(int pageNumber = 1, int pageSize = 10);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> IsUserNameExistAsync(string userName);
        Task<bool> IsEmailExistAsync(string email);
    }
}
