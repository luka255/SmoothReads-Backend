using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repo.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetBooksByGenre(string genre)
        {
            var books = await _repo.GetBooksByGenreAsync(genre);

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetBooksById(int id)
        {
            var book = await _repo.GetBookByIdAsync(id);

            if (book == null) 
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _repo.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBooksById), new {id = book.Id}, book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int bookId, Book updatedBook)
        {
            if (bookId != updatedBook.Id)
                return BadRequest();

            await _repo.UpdateBookAsync(bookId, updatedBook);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var book = await _repo.GetBookByIdAsync(bookId);

            if(book == null)
                return BadRequest();

            await _repo.DeleteBookAsync(bookId);
            return Ok();
        }
    }
}
