using BaseArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(User user, string password);
        Task<IdentityResult> ChangePasswordAsync(User user, string CurrentPassword, string NewPassword);

    }
}
