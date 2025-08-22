
using CQRSBook.Domain.Entities;

namespace CQRSBook.Application.Interfaces;

public interface IBookWriteRepository
{
    Task<long> AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Book book);
}
