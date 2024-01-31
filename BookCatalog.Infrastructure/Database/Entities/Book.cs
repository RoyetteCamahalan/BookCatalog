using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Infrastructure.Database.Entities
{
    public class Book
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishDateUtc { get; set; }

        public virtual Category Category { get; }
    }
}
