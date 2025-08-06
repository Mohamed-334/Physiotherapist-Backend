using BaseArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BaseArchitecture.Service.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(User user, string password);
        Task SignInAsync(User user, bool IsPersistent);
        Task<(JwtSecurityToken, string)> GenerateToken(User user);
        Task<List<Claim>> GetClaims(User user);
        Task<SignInResult> CheckSignInPassword(User user, string? Password, bool LockedOnFailure);

        Task<IdentityResult> ChangePasswordAsync(User user, string CurrentPassword, string NewPassword);

    }
}
