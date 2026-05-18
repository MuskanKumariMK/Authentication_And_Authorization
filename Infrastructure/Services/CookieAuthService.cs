using Core.DTOs.Auth;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CookieAuthService : IAuthService
    {
        private readonly ICookieService _cookieService;

        public CookieAuthService(ICookieService cookieService)
        {
            _cookieService = cookieService;
        }

        public async Task LoginAsync(HttpContext context, User user)
        {
            var claims = _cookieService.GenerateClaims(user);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public async Task LogoutAsync(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public CurrentUserDto? GetCurrentUser(HttpContext context)
        {
            var user = context.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            return new CurrentUserDto
            {
                UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Name = user.FindFirst(ClaimTypes.Name)?.Value,
                Email = user.FindFirst(ClaimTypes.Email)?.Value
            };
        }
    }
}
