using System;
using Microsoft.EntityFrameworkCore;
using SmoothReads_Backend.Data;
using SmoothReads_Backend.DTOs.Book;
using SmoothReads_Backend.Interfaces;
using SmoothReads_Backend.Models;
using SmoothReads_Backend.DTOs;
using SmoothReads_Backend.Mappers;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SmoothReads_Backend.Interfaces.Repositories
{
    public class BookRepository : IBookRepository
	{
		private readonly ApplicationDBContext _context;
		public BookRepository(ApplicationDBContext context)
		{
			_context = context;
		}
        public async Task<Book> AddBookAsync(AddBookDto bookDto)
        {
            var bookModel = bookDto.ToBookFromCreateDTO();

            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();

            return bookModel;
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
        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .ToListAsync();

            var bookDto = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                Description = b.Description,
                PublicationYear = b.PublicationYear,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl,
                Comments = b.Comments
            }).ToList();

            return bookDto;
        }
        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Comments)
                .Include(b => b.Favourites)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<List<Book>> GetBooksByGenreAsync(string genre)
        {
            return await _context.Books.Where(b => b.Genre == genre).ToListAsync();
        }
        public async Task<Book?> UpdateBookAsync(int bookId, UpdateBookDto updatedBook)
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

            await _context.SaveChangesAsync();
            return bookModel;
        }
        public Task<bool> BookExist(int bookId)
        {
            return _context.Books.AnyAsync(b => b.Id == bookId);
        }
    }
}