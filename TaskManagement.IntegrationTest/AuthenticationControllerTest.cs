using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Abstractions.Identity;
using TaskManagement.Controllers;
using TaskManagement.Infrastructure.Services.Identity;
using TaskManagement.Test.Common.Fakes;

namespace TaskManagement.IntegrationTest
{
    public class Tests
    {
        private AuthenticationController _authenticationController;
        [SetUp]
        public void Setup()
        {
            IIdentityService identityService = new IdentityService(
                new FakeUserManager(new FakeUserAppStore(), null!, null!, null!, null!, null!, null!, null!, null!), new FakeJwtOption());
            _authenticationController = new AuthenticationController(identityService);
        }

        [Test]
        public async Task SignupTest()
        {
            IActionResult actionResult = await _authenticationController.Signup(new Infrastructure.Common.Models.Identity.UserSignupDto() { UserName = "Ali" });
            Assert.IsTrue(actionResult is OkObjectResult);
        }
    }
}