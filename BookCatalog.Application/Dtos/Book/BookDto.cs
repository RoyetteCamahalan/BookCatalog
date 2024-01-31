using BookCatalog.Application.Dtos.Category;

namespace BookCatalog.Application.Dtos.Book
{
    public class BookDto
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public CategoryDto Category { get; set; }
    }
}
