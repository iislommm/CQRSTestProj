using CQRSBook.Domain.Entities;

namespace CQRSBook.Application.Interfaces;

public interface IBookReadRepository
{
    Task<Book?> GetByIdAsync(long id);
    Task<List<Book>> GetAllAsync();
}