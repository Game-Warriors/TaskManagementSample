using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Application.Exceptions.Identities
{
    public class CreateUserFailedException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; }

        public CreateUserFailedException(IEnumerable<IdentityError> errors) : base("Creating new application user failed")
        {
            Errors = errors;
        }
    }
}
