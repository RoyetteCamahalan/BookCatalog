using BookCatalog.Application.Dtos.Book;
using BookCatalog.Domain.Common;
using MediatR;

namespace BookCatalog.Application.Queries.Book
{
    public record GetAllBooksQuery(
        string search,
        int pageNumber,
        int pageSize
        ) : IRequest<PaginatedRequest<BookDto>>;
}
