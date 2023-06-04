using Microsoft.AspNetCore.Identity;
using TaskManagement.Application.Abstractions.Identity;

namespace TaskManagement.Infrastructure.Services.Identity
{
    public class ApplicationUser : IdentityUser, IAppUser
    {
    }
}
