using TaskManagement.Application.Abstractions.Identity;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Exceptions.Identities;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Infrastructure.Common.Models.Identity;
using TaskManagement.Infrastructure.Services.Identity;
using TaskManagement.Test.Common.Fakes;

namespace TaskManagement.Application.UnitTest.Services
{
    internal class IdentityServiceTest
    {
        private IIdentityService _identityService;

        [SetUp]
        public void Setup()
        {
            _identityService = new IdentityService(
                new FakeUserManager(new FakeUserAppStore(), null!, null!, null!, null!, null!, null!, null!, null!), new FakeJwtOption());
        }

        [Test]
        public async Task CreateUserTest()
        {
            bool isSuccess = await _identityService.CreateUser(new UserSignupDto() { UserName = "Ali" });
            Assert.IsTrue(isSuccess);
            Assert.IsNotNull(_identityService.CurrentUser );
        }

        [Test]
        public void CreateSameUserTest()
        {
            Assert.CatchAsync<CreateUserFailedException>(async () => await _identityService.CreateUser(new UserSignupDto() { UserName = "Mahdi" }));
        }
    }
}
