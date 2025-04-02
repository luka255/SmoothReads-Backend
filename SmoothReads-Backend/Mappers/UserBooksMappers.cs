using SmoothReads_Backend.DTOs.UserBooks;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Mappers
{
    public static class UserBooksMappers
    {
        public static WantToRead CreateWantToReadDto(this  AddWantToReadDto dto)
        {
            return new WantToRead
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
                //UserName = dto.UserName,
                //BookTitle = dto.BookTitle,
            };
        }
        public static Read CreateReadDto(this AddReadDto dto)
        {
            return new Read
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
                //UserName = dto.UserName,
                //BookTitle = dto.BookTitle,
            };
        }
    }
}
