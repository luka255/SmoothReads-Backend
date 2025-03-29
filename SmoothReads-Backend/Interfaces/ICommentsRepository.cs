using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmoothReads_Backend.Interfaces
{
    public interface ICommentsRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<List<Comment>> GetCommentsByBookIdAsync(int bookId);
        Task<Comment?> GetCommentByIdAsync(int Id);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment?> DeleteCommentAsync(int commentId);
    }
} 
