using BaseArchitecture.Domain.Entities;
using BaseArchitecture.Domain.Shared.JwtModels;
using BaseArchitecture.Infrastructure.Shared.Localization;
using BaseArchitecture.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseArchitecture.Service.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<AppLocalization> _stringLocalizer;
        private readonly SignInManager<User> _signManager;
        private readonly JwtSettings _jwtSettings;
        #endregion

        #region Constructor
        public AuthenticationService(UserManager<User> userManager, IStringLocalizer<AppLocalization> stringLocalizer, SignInManager<User> signManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _signManager = signManager;
            _jwtSettings = jwtSettings;
        }
        #endregion

        #region Methods

        public async Task<IdentityResult> SignUpAsync(User user, string password) => await _userManager.CreateAsync(user, password);
        public async Task SignInAsync(User user, bool IsPersistent) => await _signManager.SignInAsync(user, IsPersistent);
        public async Task<SignInResult> CheckSignInPasswordAsync(User user, string? Password, bool LockedOnFailure) => await _signManager.CheckPasswordSignInAsync(user, Password, LockedOnFailure);

        public async Task<(JwtSecurityToken, string)> GenerateTokenAsync(User user)
        {
            var claims = await GetClaimsAsync(user);
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                    SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }
        public async Task<List<Claim>> GetClaimsAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.GivenName, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("ProfileImage", user.ProfileImage ?? ""),
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            return claims;
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string CurrentPassword, string NewPassword)
                                                             => await _userManager.ChangePasswordAsync(user, CurrentPassword, NewPassword);
        public async Task<string> GenerateOtpAsync(User user) => await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
        public async Task<bool> VerifyOtpAsync(User user, string otp) => await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider, otp);

        public async Task<IdentityResult> ResetPasswordAsync(User user, string password)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            return result;
        }


        #endregion
    }
}
