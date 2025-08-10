using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using BaseArchitecture.Service.Shared.ExtensionMethods;
using BaseArchitecture.Service.Shared.PaginatedList;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Data;

namespace BaseArchitecture.Service.Service
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        #endregion

        #region Constructor
        public UserService(UserManager<User> userManager, IStringLocalizer<AppLocalization> stringLocalizer)
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Methods
        public async Task<List<User>?> GetAll()
        {
            var Users = await _userManager.Users.ToListAsync();
            return Users;
        }
        public async Task<User?> GetById(int id)
        {
            var User = await _userManager.Users
                            .Where(u => u.Id == id)
                            .FirstOrDefaultAsync();
            return User;
        }
        public async Task<IdentityResult> EditAsync(User entity)
        {
            var result = await _userManager.UpdateAsync(entity);
            return result;
        }
        public async Task<IdentityResult> HardDeleteAsync(User entity)
        {
            var result = await _userManager.DeleteAsync(entity);
            return result;
        }
        public async Task<PaginatedList<User>> GetPaginatedList(int pageNumber = 1, int pageSize = 10)
        {
            var Users = _userManager.Users
                                    .AsQueryable();

            var PaginatedList = await Users.ToPaginatedListAsync(pageNumber, pageSize);
            return PaginatedList;
        }
        public async Task<List<string>> GetUserRoles(User user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }
        public async Task<IdentityResult> AddUserToRole(User user, string role) => await _userManager.AddToRoleAsync(user, role);
        public async Task<bool> IsUserInRole(User user, string role) => await _userManager.IsInRoleAsync(user, role);
        public async Task<User?> GetUserByEmail(string email) => await _userManager.FindByEmailAsync(email);
        public async Task<bool> IsUserNameExist(string userName) => (await _userManager.FindByNameAsync(userName)) != null;
        public async Task<bool> IsEmailExist(string email) => (await _userManager.FindByEmailAsync(email)) != null;
        #endregion
    }


}
