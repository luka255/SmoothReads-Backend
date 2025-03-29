using System;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> GetBooksByGenreAsync(string genre);
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book?> UpdateBookAsync(int bookId, Book updatedBook);
        Task<Book?> DeleteBookAsync(int bookId);
    }
}