using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;

namespace CQRSBook.Infrastructure.Persistence.Repositories;

public class BookWriteRepository : IBookWriteRepository
{

    private readonly AppDbContext _appDbContext;

    public BookWriteRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<long> AddAsync(Book book)
    {
        await _appDbContext.Books.AddAsync(book);
        await _appDbContext.SaveChangesAsync();
        return book.BookId;
    }

    public Task DeleteAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Book book)
    {
        throw new NotImplementedException();
    }
}