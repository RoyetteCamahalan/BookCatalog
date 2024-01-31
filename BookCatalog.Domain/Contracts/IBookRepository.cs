using BookCatalog.Domain.Common;
using BookCatalog.Domain.Models;

namespace BookCatalog.Domain.Contracts
{
    public interface IBookRepository
    {
        Task<long> Add(Book book);

        Task<PaginatedRequest<Book>> GetAll(string search, int pageNumber, int pageSize);
        Task Update(Book book);
        Task<Book> GetBookById(long Id);
    }
}
