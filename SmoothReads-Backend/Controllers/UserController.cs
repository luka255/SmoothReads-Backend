using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.DTOs.User;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repo.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _repo.GetUserByEmailAsync(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDto newUser)
        {
           
            var userModel = await _repo.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new {id = userModel.Id} , userModel);
        }
    }
}
