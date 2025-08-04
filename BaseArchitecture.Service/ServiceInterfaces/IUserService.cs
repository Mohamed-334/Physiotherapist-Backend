using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Service.Shared.PaginatedList;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<User>?> GetAll();
        Task<User?> GetById(int id);
        Task<string> EditAsync(User entity);
        Task<string> HardDeleteAsync(User entity);
        Task<string> SoftDeleteAndActivationAsync(int id);
        Task<PaginatedList<User>> GetPaginatedList(int pageNumber = 1, int pageSize = 10);
    }
}
