using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSBook.Infrastructure.Persistence.Repositories;

public class BookReadRepository : IBookReadRepository
{
    private readonly AppDbContext _appDbContext;

    public BookReadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var books = await _appDbContext.Books.ToListAsync();
        return books;
    }

    public Task<Book?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}