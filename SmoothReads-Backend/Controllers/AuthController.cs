using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.Interfaces;
using Microsoft.IdentityModel.Tokens;
using SmoothReads_Backend.Interfaces.Repositories;
using SmoothReads_Backend.DTOs.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace SmoothReads_Backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        public AuthController(IConfiguration config, IUserRepository userRepo)
        {
            _config = config;
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] DTOs.User.LoginRequest request)
        {
            var user = await _userRepo.GetUserByEmailAsync(request.Email);

            if (user == null)
                return Unauthorized("invalid email or password");

            var isPasswordValid = VerifyPassword(request.Password, user.Password);

            if (!isPasswordValid)
                return Unauthorized("invalid email or password");

            var token = GenerateJwtToken(user.Email, "User");
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
        {
            var existingUser = await _userRepo.GetUserByEmailAsync(userDto.Email);

            if (existingUser != null)
                return BadRequest("User with this email already exists");

            userDto.Password = HashPassword(userDto.Password);

            var newUser = await _userRepo.AddUserAsync(userDto);
            return Ok(new { message = "User registered successfully!", userId = newUser.Id });
        }
        private string GenerateJwtToken(string email, string role)
        {
            var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);    
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        }
    }
}
