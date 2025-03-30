using Microsoft.AspNetCore.Mvc;
using SmoothReads_Backend.Data;
using SmoothReads_Backend.DTOs.Comment;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Mappers;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsRepository _repo;
        private readonly IBookRepository _bookRepo;
        public CommentController(ICommentsRepository repo,IBookRepository bookRepo) 
        {
            _repo = repo;
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _repo.GetAllCommentsAsync();
            return Ok(comments);
        }
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comments = await _repo.GetCommentByIdAsync(id);

            if (comments == null)
                return NotFound();

            return Ok(comments);
        }

        [HttpGet("byBook/{bookId}")]
        public async Task<IActionResult> GetCommentsByBookId(int bookId)
        {
            var comments = await _repo.GetCommentsByBookIdAsync(bookId);

            if (comments == null) 
                return NotFound();

            return Ok(comments);
        }

        [HttpPost("{bookId}")]
        public async Task<IActionResult> AddComment([FromRoute] int bookId, [FromBody] AddCommentDto commentDto)
        {
            if (!await _bookRepo.BookExist(bookId))
                return BadRequest("book does not exsit");

            var commentModel = commentDto.ToCommentFromCreateDto(bookId);
            await _repo.AddCommentAsync(commentModel);
            return CreatedAtAction(nameof(GetCommentById),new {id = commentModel.Id} ,commentModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _repo.GetCommentByIdAsync(id);

            if (comment == null) 
                return NotFound();
            

            await _repo.DeleteCommentAsync(id);
            return Ok();    
        }
    }
}
