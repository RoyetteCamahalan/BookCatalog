namespace BookCatalog.Domain.Models
{
    public class Book
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public Category Category { get; set; }
    }
}
