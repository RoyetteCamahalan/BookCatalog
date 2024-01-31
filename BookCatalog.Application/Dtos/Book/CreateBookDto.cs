using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Application.Dtos.Book
{
    public class CreateBookDto
    {
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
