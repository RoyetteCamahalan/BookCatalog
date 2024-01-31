using MediatR;

namespace BookCatalog.Application.Commands.Book
{
    public record UpdateBookCommand(
        long Id,
        int CategoryId,
        string Title,
        string Description,
        DateTime PublishDateUtc) : IRequest;
}
