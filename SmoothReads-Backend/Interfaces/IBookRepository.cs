using System;
using SmoothReads_Backend.DTOs.Book;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<List<Book>> GetBooksByGenreAsync(string genre);
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(AddBookDto book);
        Task<Book?> UpdateBookAsync(int bookId, UpdateBookDto updatedBook);
        Task<Book?> DeleteBookAsync(int bookId);
        Task<bool> BookExist(int bookId);
    }
}