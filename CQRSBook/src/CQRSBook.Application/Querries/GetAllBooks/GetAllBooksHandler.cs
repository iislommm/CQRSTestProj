using CQRSBook.Application.Dtos;
using MediatR;

namespace CQRSBook.Application.Querries.GetAllBooks;

public record GetAllBooksHandler() : IRequest<ICollection<BookGetDto>>;
