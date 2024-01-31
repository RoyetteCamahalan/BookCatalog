namespace BookCatalog.Domain.Common
{
    public class PaginatedRequest<T>
    {
        public int totalPages { get; set; }
        public int pageNumber { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
