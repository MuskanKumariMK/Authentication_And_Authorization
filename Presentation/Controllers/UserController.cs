using Core.Common;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_And_Authorization.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
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
    }
}
