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
        public async Task<IActionResult> GetWantToReadBooks([FromQuery] int userId)
        {
            var wtrBooks = await _repo.GetWantToReadBooksAsync(userId);
            return Ok(wtrBooks);
        }

        [HttpGet("Read")]
        public async Task<IActionResult> GetReadBooks([FromQuery] int userId)
        {
            var readBooks = await _repo.GetReadBooksAsync(userId);
            return Ok(readBooks);
        }

        [HttpPost("want-to-read")]
        public async Task<IActionResult> AddWantToReadBooks([FromQuery] WantToRead wantToRead)
        {
            var WantToRead = await _repo.AddWantToReadBooksAsync(wantToRead);
            return CreatedAtAction(nameof(GetWantToReadBooks), new { id = wantToRead.Id }, wantToRead);
        }

        [HttpPost("read-books")]
        public async Task<IActionResult> AddReadBooks([FromQuery] Read read)
        {
            var readbook = await _repo.AddReadBooksAsync(read);
            return CreatedAtAction(nameof(GetReadBooks), new { id = read.Id }, read);
        }

        [HttpDelete("want-to-read/{userId}/{bookId}")]
        public async Task<IActionResult> DeleteWantToReadBook(int userId, int bookId)
        {
            var deletedBook = await _repo.DeleteWantToReadBookAsync(userId, bookId);

            if (deletedBook == null)
                return BadRequest();

            return Ok(deletedBook);
        }
        [HttpDelete("read/{userId}/{bookId}")]
        public async Task<IActionResult> DeleteReadBook(int userId, int bookId)
        {
            var deletedBook = await _repo.DeleteReadBookAsync(userId, bookId);

            if (deletedBook == null)
                return BadRequest();

            return Ok(deletedBook);
        }
    }
}
