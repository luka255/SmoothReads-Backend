using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmoothReads_Backend.DTOs.Comment;

namespace SmoothReads_Backend.Interfaces
{
    public interface ICommentsRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<List<Comment>> GetCommentsByBookIdAsync(int bookId);
        Task<List<Comment>?> GetCommentByIdAsync(int Id);
        Task<Comment?> AddCommentAsync(Comment commentModel);
        Task<Comment?> DeleteCommentAsync(int commentId);
    }
} 
