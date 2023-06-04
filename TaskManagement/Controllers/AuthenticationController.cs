using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Abstractions.Identity;
using TaskManagement.Infrastructure.Common.Models.Identity;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IIdentityService _identityService;

        public AuthenticationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signup([FromBody] UserSignupDto signupData)
        {
            bool isSuccess = await _identityService.CreateUser(signupData);
            if (isSuccess)
            {
                string tokenString = await _identityService.CreateToken();
                return Ok(new { token = tokenString, Scheme = JwtBearerDefaults.AuthenticationScheme });
            }

            return BadRequest();
        }
    }
}