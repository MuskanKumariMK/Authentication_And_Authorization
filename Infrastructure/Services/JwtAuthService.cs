using Core.Common;
using Core.DTOs.Auth;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class JwtAuthService(
         IOptions<JwtSettings> jwtOptions,
         ICookieService cookieService) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        public Task<string> LoginAsync(User user)
        {
            var claims = cookieService.GenerateClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(tokenString);
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

        public Task LoginAsync(HttpContext context, User user)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
