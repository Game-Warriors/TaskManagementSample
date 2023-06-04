namespace TaskManagement.Application.Abstractions.Identity
{
    public interface IIdentityService
    {
        IAppUser CurrentUser { get; }
        ValueTask<bool> CreateUser(IUserSignupData userData);
        ValueTask<string> CreateToken();
        ValueTask<bool> ValidateUser(IUserSignupData userData);
    }
}
