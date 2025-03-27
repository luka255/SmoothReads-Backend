using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICommentsRepository
{
    Task<IEnumerable<Comment>> GetCommentsByBookIdAsync(int bookId);
    Task<Comment> AddCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(int commentId);
}
