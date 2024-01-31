using BookCatalog.Application.Dtos.Book;
using MediatR;

namespace BookCatalog.Application.Queries.Book
{
    public record GetBookByIdQuery(long id) : IRequest<BookDto>;
}
