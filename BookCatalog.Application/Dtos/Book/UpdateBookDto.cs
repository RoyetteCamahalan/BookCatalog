using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Application.Dtos.Book
{
    public class UpdateBookDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishDateUtc { get; set; }
    }
}
