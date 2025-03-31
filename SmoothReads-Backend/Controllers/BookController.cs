using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.Data;
using SmoothReads_Backend.DTOs.Book;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Mappers;
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
        public async Task<IActionResult> AddBook([FromBody] AddBookDto bookDto)
        {
            var bookModel = await _repo.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBooksById), new {id = bookModel.Id}, bookModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] UpdateBookDto updatedBook)
        {
            var bookModel = await _repo.UpdateBookAsync(bookId, updatedBook);

            if (bookModel == null)  
                return NotFound();

            return Ok(bookModel.ToBookDto());
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
