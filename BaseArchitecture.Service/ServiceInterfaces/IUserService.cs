using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Service.Shared.PaginatedList;
using Microsoft.AspNetCore.Identity;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<User>?> GetAll();
        Task<User?> GetById(int id);
        Task<IdentityResult> EditAsync(User entity);
        Task<IdentityResult> HardDeleteAsync(User entity);
        Task<PaginatedList<User>> GetPaginatedList(int pageNumber = 1, int pageSize = 10);
        Task<User?> GetUserByEmail(string email);
        Task<bool> IsUserNameExist(string userName);
        Task<bool> IsEmailExist(string email);
    }
}
