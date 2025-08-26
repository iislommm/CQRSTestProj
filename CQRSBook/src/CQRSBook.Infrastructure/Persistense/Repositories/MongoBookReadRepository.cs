﻿using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;
using MongoDB.Driver;

namespace CQRSBook.Infrastructure.Persistence.Repositories;

public class MongoBookReadRepository : IBookReadRepository
{
    private readonly IMongoCollection<Book> _books;

    public MongoBookReadRepository(IMongoDatabase database)
    {
        _books = database.GetCollection<Book>("books");
    }

    public async Task<Book?> GetByIdAsync(long id)
    {
        var filter = Builders<Book>.Filter.Eq(b => b.BookId, id);
        return await _books.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _books.Find(FilterDefinition<Book>.Empty).ToListAsync();
    }
}