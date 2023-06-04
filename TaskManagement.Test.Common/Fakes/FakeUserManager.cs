using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskManagement.Infrastructure.Services.Identity;

namespace TaskManagement.Test.Common.Fakes
{
    public class FakeResult : IdentityResult
    {
        public FakeResult(bool Succeed)
        {
            Succeeded = true;
        }
    }

    public class FakeUserManager : UserManager<ApplicationUser>
    {

        public FakeUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            if (user?.UserName?.Equals("Mahdi", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                IdentityResult result = new IdentityResult();
                return Task.FromResult(result);
            }
            else
            {
                return Task.FromResult((IdentityResult)new FakeResult(true));
            }
        }

        public override Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            IList<string> roles = new List<string>();
            return Task.FromResult(roles);
        }
    }
}
