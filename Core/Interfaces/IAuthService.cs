using Core.DTOs.Auth;
using Core.Models;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task LoginAsync(HttpContext context, User user);

        Task LogoutAsync(HttpContext context);
        CurrentUserDto? GetCurrentUser(HttpContext context);
    }
}
