using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Infrastructure.Database.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
