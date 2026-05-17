using System.Security.Claims;

namespace Core.Interfaces
{
    public interface ICookieService
    {
        List<Claim> GenerateClaims(Models.User user);
    }
}
