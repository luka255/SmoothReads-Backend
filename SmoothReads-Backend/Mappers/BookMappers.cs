using SmoothReads_Backend.DTOs.Book;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Genre = bookModel.Genre,
                Description = bookModel.Description,
                PublicationYear = bookModel.PublicationYear,
                Rating = bookModel.Rating,
                ImageUrl = bookModel.ImageUrl,
            };
        }
        public static Book ToBookFromCreateDTO(this AddBookDto bookModel)
        {
            return new Book
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Genre = bookModel.Genre,
                Description = bookModel.Description,
                PublicationYear = bookModel.PublicationYear,
                Rating = bookModel.Rating,
                ImageUrl = bookModel.ImageUrl,
            };
        }
    }
}
