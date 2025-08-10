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
    public class RoleService : IRoleService
    {
        #region Fields

        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        #endregion

        #region Constructor
        public RoleService(RoleManager<Role> roleManager, IStringLocalizer<AppLocalization> stringLocalizer, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task<List<Role>?> GetAll()
        {
            var Roles = await _roleManager.Roles.ToListAsync();
            return Roles;
        }
        public async Task<Role?> GetById(int id)
        {
            var Role = await _roleManager.Roles
                            .Where(u => u.Id == id)
                            .FirstOrDefaultAsync();
            return Role;
        }
        public async Task<IdentityResult> AddRole(Role role)
        {
            var result = await _roleManager.CreateAsync(role);
            return result;
        }
        public async Task<bool> RoleIsUsed(int roleId)
        {
            var role = await GetById(roleId);
            var Users = await _userManager.GetUsersInRoleAsync(role.Name);
            return Users != null && Users.Count > 0;
        }
        public async Task<IdentityResult> EditAsync(Role entity)
        {
            var result = await _roleManager.UpdateAsync(entity);
            return result;
        }
        public async Task<IdentityResult> HardDeleteAsync(Role entity)
        {
            var result = await _roleManager.DeleteAsync(entity);
            return result;
        }
        public async Task<PaginatedList<Role>> GetPaginatedList(int pageNumber = 1, int pageSize = 10)
        {
            var Users = _roleManager.Roles
                                    .AsQueryable();

            var PaginatedList = await Users.ToPaginatedListAsync(pageNumber, pageSize);
            return PaginatedList;
        }
        public async Task<bool> IsRoleNameExist(string RoleName) => (await _roleManager.FindByNameAsync(RoleName)) != null;
        #endregion
    }


}
