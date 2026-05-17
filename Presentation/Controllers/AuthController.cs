using Core.DTOs.Auth;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthController(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }
            if (!PasswordValidator.IsStrong(dto.Password))
            {
                return BadRequest("Password must contain uppercase, lowercase and number");
            }
            string salt = SaltGenerator.GenerateSalt();
            var hashedPassword = _passwordService.HashPassword(dto.Password, salt);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Salt = salt
            };

            await _userRepository.AddAsync(user);

            return Ok("User registered successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            string hashedPassword = _passwordService.HashPassword(dto.Password, user.Salt);

            bool isPasswordValid = hashedPassword == user.PasswordHash;

            //bool isPasswordValid = _passwordService.VerifyPassword(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok("Login successful");
        }
    }
}