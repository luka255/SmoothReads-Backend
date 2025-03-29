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

        [HttpPost("want-to-read")]
        public async Task<IActionResult> AddWantToReadBooks(WantToRead wantToRead)
        {
            var WantToRead = await _repo.AddWantToReadBooksAsync(wantToRead);
            return Ok(WantToRead);
        }

        [HttpPost("read-books")]
        public async Task<IActionResult> AddReadBooks(Read Read)
        {
            var readbook = await _repo.AddReadBooksAsync(Read);
            return Ok(readbook);
        }

        [HttpDelete("want-to-read/{userId}/{bookId}")]
        public async Task<IActionResult> DeleteWantToReadBook(int userId, int bookId)
        {
            var wtrBook = await _repo.GetWantToReadBooksAsync(userId);

            if (wtrBook == null)
                return BadRequest();

            await _repo.DeleteWantToReadBookAsync(userId, bookId);

            return Ok();
        }
        [HttpDelete("read/{userId}/{bookId}")]
        public async Task<IActionResult> DeleteReadBook(int userId, int bookId)
        {
            var readBook = await _repo.GetReadBooksAsync(userId);

            if (readBook == null)
                return BadRequest();

            await _repo.DeleteReadBookAsync(userId, bookId);

            return Ok();
        }
    }
}
