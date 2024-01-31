using MediatR;

namespace BookCatalog.Application.Commands.Book
{
    public record CreateBookCommand(
        int CategoryId,
        string Title,
        string Description,
        DateTime PublishDateUtc) : IRequest<long>;
}
