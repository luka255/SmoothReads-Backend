using System;
using SmoothReads_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserBooksRepository
{
    Task<IEnumerable<WantToRead>> GetWantToReadBooksAsync(int userId);
    Task<IEnumerable<Read>> GetReadBooksAsync(int userId);
    Task<WantToRead> AddWantToReadBooksAsync(WantToRead wantToRead);
    Task<Read> AddReadBooksAsync(Read Read);
    Task<bool> DeleteWantToReadBookAsync(int userId, int bookId);
    Task<bool> DeleteReadBookAsync(int userId, int bookId);
}
