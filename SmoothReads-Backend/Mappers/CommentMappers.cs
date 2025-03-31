using SmoothReads_Backend.DTOs.Comment;
using SmoothReads_Backend.Models;
using System.Net;
using System.Runtime.CompilerServices;

namespace SmoothReads_Backend.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                BookId = commentModel.BookId,
                Text = commentModel.Text,
                CreatedAt = commentModel.CreatedAt,
                Rating = commentModel.Rating,
            };
        }

        public static Comment ToCommentFromCreateDto(this AddCommentDto CommentDto, int bookId,int userId)
        {
            return new Comment
            {
                Text = CommentDto.Text,
                CreatedAt = CommentDto.CreatedAt,
                Rating = CommentDto.Rating,
                BookId = bookId,
                UserId = userId,
            };
        }
    }
}
