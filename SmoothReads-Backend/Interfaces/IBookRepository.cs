using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<IEnumerable<Book>> GetBooksByGenreAsync(string genre);
    Task<Book> GetBookById(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book> UpdateBookAsync(int bookId, Book updatedBook);
    Task<bool> DeleteBookAsync(int bookId);
}
