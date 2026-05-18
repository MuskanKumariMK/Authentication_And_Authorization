using Core.DTOs.Auth;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class SessionAuthService : IAuthService
    {
        public Task LoginAsync(HttpContext context, User user)
        {
            context.Session.SetInt32("UserId", user.Id);
            context.Session.SetString("Name", user.Name);
            context.Session.SetString("Email", user.Email);

            return Task.CompletedTask;
        }

        public Task LogoutAsync(HttpContext context)
        {
            context.Session.Clear();
            return Task.CompletedTask;
        }
        public CurrentUserDto? GetCurrentUser(HttpContext context)
        {
            var userId = context.Session.GetInt32("UserId");

            if (userId == null)
            {
                return null;
            }

            return new CurrentUserDto
            {
                UserId = userId.ToString(),
                Name = context.Session.GetString("Name"),
                Email = context.Session.GetString("Email")
            };
        }
    }
}
