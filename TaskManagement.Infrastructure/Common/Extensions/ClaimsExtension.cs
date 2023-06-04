using System.Security.Claims;
using TaskManagement.Application.Exceptions.Identities;

namespace TaskManagement.Infrastructure.Common.Extensions
{
    public static class ClaimsExtension
    {
        public static string UserId (this ClaimsPrincipal claims)
        {
            string id = claims.Claims.FirstOrDefault(input => input.Type == ClaimTypes.Sid)?.Value ?? default!;
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrEmpty(id)) {
                throw new InvalidUserIdException();
            }
            return id;
        }
    }
}
