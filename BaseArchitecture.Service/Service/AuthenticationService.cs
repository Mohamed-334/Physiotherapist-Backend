using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace BaseArchitecture.Service.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        #endregion

        #region Constructor
        public AuthenticationService(UserManager<User> userManager, IStringLocalizer<AppLocalization> stringLocalizer)
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Methods
        public async Task<IdentityResult> SignUpAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
        public async Task<IdentityResult> ChangePasswordAsync(User user, string CurrentPassword, string NewPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, CurrentPassword, NewPassword);
            return result;
        }

        #endregion
    }
}
