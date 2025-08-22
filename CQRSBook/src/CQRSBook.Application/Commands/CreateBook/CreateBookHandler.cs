
using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;
using MediatR;

namespace CQRSBook.Application.Commands.CreateBook;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, long>
{
    private readonly IBookWriteRepository _writeRepo;
    public CreateBookHandler(IBookWriteRepository repo)
    {
        _writeRepo = repo;
    }

    public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = new Book
        {
            Title = request.Title,
            Author = request.Author,
            ISBN = request.ISBN,
            Publisher = request.Publisher,
            PublishDate = request.PublishDate,
            Pages = request.Pages,
            Genre = request.Genre,
            Language = request.Language,
            Price = request.Price
        };

        var bookId = await _writeRepo.AddAsync(entity);

        return bookId;
    }
}
