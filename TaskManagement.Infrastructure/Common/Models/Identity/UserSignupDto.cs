using TaskManagement.Application.Abstractions.Identity;

namespace TaskManagement.Infrastructure.Common.Models.Identity
{
    public class UserSignupDto : IUserSignupData
    {
        public string UserName { get; set; } = default!;
    }
}
