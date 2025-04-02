using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmoothReads_Backend.DTOs.UserBooks;

namespace SmoothReads_Backend.Interfaces
{
    public interface IUserBooksRepository
    {
        Task<List<WantToRead>> GetWantToReadBooksAsync(int userId);
        Task<List<Read>> GetReadBooksAsync(int userId);
        Task<WantToRead> AddWantToReadBooksAsync(AddWantToReadDto wantToRead);
        Task<Read> AddReadBooksAsync(AddReadDto read);
        Task<WantToRead?> DeleteWantToReadBookAsync(int userId, int bookId);
        Task<Read?> DeleteReadBookAsync(int userId, int bookId);
    }
}