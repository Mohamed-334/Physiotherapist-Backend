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
        Task<(JwtSecurityToken, string)> GenerateTokenAsync(User user);
        Task<List<Claim>> GetClaimsAsync(User user);
        Task<SignInResult> CheckSignInPasswordAsync(User user, string? Password, bool LockedOnFailure);

        Task<IdentityResult> ChangePasswordAsync(User user, string CurrentPassword, string NewPassword);
        Task<string> GenerateOtpAsync(User user);
        Task<bool> VerifyOtpAsync(User user, string otp);
        Task<IdentityResult> ResetPasswordAsync(User user, string password);

    }
}
