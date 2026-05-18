using Core.Common;
using Core.DTOs.Auth;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IAuthService _authService;

        public UserController(IUserRepository repo, IAuthService authService)
        {
            _repo = repo;
            _authService = authService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetAllAsync();
            return Ok(ApiResponse<object>.SuccessResponse(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _repo.AddAsync(user);
            return Ok(ApiResponse<object>.SuccessResponse(user));

        }
        //[Authorize]
        [ProducesResponseType(typeof(ApiResponse<CurrentUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var currentUser = _authService.GetCurrentUser(HttpContext);

            if (currentUser == null)
            {
                return Unauthorized(ApiResponse<CurrentUserDto>.FailResponse("User not authenticated"));
            }

            return Ok(ApiResponse<CurrentUserDto>.SuccessResponse(currentUser));
        }
    }
}
