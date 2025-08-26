using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;
using MongoDB.Driver;

namespace CQRSBook.Infrastructure.Persistense.Repositories
{
    public class MongoBookWriteRepository : IBookWriteRepository
    {
        private readonly IMongoCollection<Book> _books;

        public MongoBookWriteRepository(IMongoDatabase database)
        {
            _books = database.GetCollection<Book>("books");
        }

        public async Task<long> AddAsync(Book book)
        {
            if (book.BookId == 0)
                book.BookId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            await _books.InsertOneAsync(book);
            return book.BookId;
        }

        public async Task UpdateAsync(Book book)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.BookId, book.BookId);
            await _books.ReplaceOneAsync(filter, book);
        }

        public async Task DeleteAsync(Book book)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.BookId, book.BookId);
            await _books.DeleteOneAsync(filter);
        }
    }
}