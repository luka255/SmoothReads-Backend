using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using SmoothReads_Backend.DTOs.Comment;
using SmoothReads_Backend.Mappers;


namespace SmoothReads_Backend.Interfaces.Repositories
{
    public class CommentRepository : ICommentsRepository
    {
        private readonly ApplicationDBContext _Context;
        public CommentRepository(ApplicationDBContext context)
        {
            _Context = context;
        }
        public async Task<Comment?> AddCommentAsync(Comment commentModel)
        {
            await _Context.Comments.AddAsync(commentModel);
            await _Context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteCommentAsync(int commentId)
        {
            var commentModel = await _Context.Comments.FindAsync(commentId);

            if (commentModel == null)
                return null;

            _Context.Comments.Remove(commentModel);
            await _Context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _Context.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByBookIdAsync(int bookId)
        {
            return await _Context.Comments.Where(c => c.BookId == bookId).ToListAsync();
        }
        public async Task<List<Comment>?> GetCommentByIdAsync(int bookId)
        {
            return await _Context.Comments
                .Where(c => c.BookId == bookId)
                .ToListAsync();
        }
    }
}
