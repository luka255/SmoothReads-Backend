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
        private readonly IUserRepository _UserRepo;

        public CommentController(ICommentsRepository repo,IBookRepository bookRepo, IUserRepository userRepo) 
        {
            _repo = repo;
            _bookRepo = bookRepo;
            _UserRepo = userRepo;
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

        [HttpPost("{userId}/{bookId}")]
        public async Task<IActionResult> AddComment([FromRoute] int bookId, [FromRoute]int userId,[FromBody] AddCommentDto commentDto)
        {
            if (!await _bookRepo.BookExist(bookId))
                return BadRequest("book does not exsit");
            if (!await _UserRepo.UserExist(bookId))
                return BadRequest("book does not exsit");


            var commentModel = commentDto.ToCommentFromCreateDto(bookId,userId);
            //commentModel.UserId = commentDto.UserId;
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
