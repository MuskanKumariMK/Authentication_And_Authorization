using Core.Interfaces;
using Core.Models;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CookieService : ICookieService
    {
        public List<Claim> GenerateClaims(User user)
        {
            return new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),

            new Claim(ClaimTypes.Email, user.Email),

            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
        };
        }
    }
}