using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddUser(User newUser)
        {
            await _repo.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserByEmail), new {id = newUser.Id} ,newUser);
        }
    }
}
