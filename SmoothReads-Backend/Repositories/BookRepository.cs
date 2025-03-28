using System;
using System.Data.Entity;
using SmoothReads_Backend.Data;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;

namespace SmoothReads_Backend.Repositories
{
    public class BookRepository : IBookRepository
	{
		private readonly ApplicationDBContext _context;
		public BookRepository(ApplicationDBContext context)
		{
			_context = context;
		}
        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book?> DeleteBookAsync(int bookId)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            if (bookModel == null)
                return null;

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<List<Book>> GetBooksByGenreAsync(string genre)
        {
            return await _context.Books.Where(b => b.Genre == genre).ToListAsync();
        }
        public async Task<Book> UpdateBookAsync(int bookId, Book updatedBook)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            if (bookModel == null)
                return null;

            bookModel.Title = updatedBook.Title;
            bookModel.Author = updatedBook.Author;
            bookModel.Genre = updatedBook.Genre;
            bookModel.Description = updatedBook.Description;
            bookModel.PublicationYear = updatedBook.PublicationYear;
            bookModel.Rating = updatedBook.Rating;
            bookModel.ImageUrl = updatedBook.ImageUrl;
            
            _context.SaveChanges();
            return bookModel;
        }
    }
}