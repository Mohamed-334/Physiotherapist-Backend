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
        public async Task<SignInResult> CheckSignInPassword(User user, string? Password, bool LockedOnFailure) => await _signManager.CheckPasswordSignInAsync(user, Password, LockedOnFailure);

        public async Task<(JwtSecurityToken, string)> GenerateToken(User user)
        {
            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }
        public async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
                new Claim(nameof(UserClaimModel.Id), user.Id.ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            return claims;
        }
        public async Task<IdentityResult> ChangePasswordAsync(User user, string CurrentPassword, string NewPassword)
                                                             => await _userManager.ChangePasswordAsync(user, CurrentPassword, NewPassword);


        #endregion
    }
}
