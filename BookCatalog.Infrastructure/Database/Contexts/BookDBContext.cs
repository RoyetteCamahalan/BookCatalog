using BookCatalog.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Database.Contexts
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().
                HasOne(x => x.Category);


            modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Adventure"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Comics"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Drama"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Fantasy"
                    }
                );
            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        CategoryId = 1,
                        Title = "Adventure Book 1",
                        Description = "Test",
                        PublishDateUtc = DateTime.UtcNow,
                    },
                    new Book
                    {
                        Id = 2,
                        CategoryId = 1,
                        Title = "Adventure Book 2",
                        Description = "Test",
                        PublishDateUtc = DateTime.UtcNow,
                    },
                    new Book
                    {
                        Id = 3,
                        CategoryId = 2,
                        Title = "Spider Man",
                        Description = "Test",
                        PublishDateUtc = DateTime.UtcNow,
                    }
                );
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
