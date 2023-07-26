using Microsoft.AspNetCore.Identity;

namespace ShrimplyAPI.Repository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
