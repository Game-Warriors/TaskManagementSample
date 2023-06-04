using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Identity;
using TaskManagement.Application.Exceptions.Identities;
using TaskManagement.Infrastructure.Options;

namespace TaskManagement.Infrastructure.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;
        private ApplicationUser _appUser;

        public IAppUser CurrentUser => _appUser;

        public IdentityService(UserManager<ApplicationUser> userManager, IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _jwtOptions = options.Value;
            _appUser = default!;
        }

        public async ValueTask<bool> CreateUser(IUserSignupData userData)
        {
            _appUser = new ApplicationUser() { UserName = userData.UserName };
            IdentityResult result = await _userManager.CreateAsync(_appUser);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new CreateUserFailedException(result.Errors);
            }
        }

        public async ValueTask<string> CreateToken()
        {
            JwtSecurityTokenHandler tokenHandler = new();
            IList<string> rolse = await _userManager.GetRolesAsync(_appUser);
            IEnumerable<Claim> claims = GetClaims(rolse);
            JwtSecurityToken token = new(_jwtOptions.Issuer, _jwtOptions.Audience,
                claims, null, DateTime.UtcNow.AddHours(_jwtOptions.HourLifeTime), CreateSigningCredential());

            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public async ValueTask<bool> ValidateUser(IUserSignupData userData)
        {
            _appUser = await _userManager.FindByNameAsync(userData.UserName) ?? default!;
            return _appUser != null;
        }

        private SigningCredentials CreateSigningCredential()
        {
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            SigningCredentials signing = new(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature);
            return signing;
        }

        private IEnumerable<Claim> GetClaims(IList<string> roles)
        {
            if (!string.IsNullOrEmpty(_appUser.UserName))
                yield return new Claim(ClaimTypes.Name, _appUser.UserName);
            yield return new Claim(ClaimTypes.Sid, _appUser.Id);
            if (roles != null)
            {
                foreach (string role in roles)
                {
                    yield return new Claim(ClaimTypes.Role, role);
                }
            }
        }
    }
}
