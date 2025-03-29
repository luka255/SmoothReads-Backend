using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private readonly IUserBooksRepository _repo;
        public UserBooksController(IUserBooksRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("WantToRead")]
        public async Task<IActionResult> GetWantToReadBooks(int userId)
        {
            var wtrBooks = await _repo.GetWantToReadBooksAsync(userId);
            return Ok(wtrBooks);
        }

        [HttpGet("Read")]
        public async Task<IActionResult> GetReadBooks(int userId)
        {
            var readBooks = await _repo.GetReadBooksAsync(userId);
            return Ok(readBooks);
        }

        [HttpPost("add WantToRead")]
        public async Task<IActionResult> AddWantToReadBooks(WantToRead wantToRead)
        {

        }
    }
}
