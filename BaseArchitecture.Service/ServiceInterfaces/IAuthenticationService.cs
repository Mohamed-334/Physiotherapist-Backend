using BaseArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(User user, string password);
        Task<bool> IsUserNameExist(string userName);
        Task<bool> IsEmailExist(string email);
    }
}
