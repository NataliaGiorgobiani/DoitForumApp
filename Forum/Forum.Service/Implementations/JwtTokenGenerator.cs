using Forum.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Forum.Service.Implementations
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(IdentityUser applicationUser, IEnumerable<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
