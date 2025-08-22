using MediatR;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CQRSBook.Application.Commands.CreateBook;

public record CreateBookCommand(
string Title,
string Author,
string ISBN,
string Publisher,
DateTime PublishDate,
int Pages,
string Genre,
string Language,
decimal Price
) : IRequest<long>;  
