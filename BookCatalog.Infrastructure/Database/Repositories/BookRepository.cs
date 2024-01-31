using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookCatalog.Domain.Common;
using BookCatalog.Domain.Contracts;
using BookCatalog.Domain.Models;
using BookCatalog.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _db;
        private readonly IMapper _mapper;

        public BookRepository(BookDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        private async Task<Entities.Book> FindBookById(long id)
        {
            return await _db.Books.FindAsync(id);
        }
        public async Task<long> Add(Book book)
        {
            var entity = _mapper.Map<Entities.Book>(book);
            _db.Books.Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<PaginatedRequest<Book>> GetAll(string search, int pageNumber, int pageSize)
        {
            var result = _db.Books.Include(x => x.Category).
                Where(x => x.Title.Contains(search)).OrderBy(x => x.Title);
            var paginatedRequest = new PaginatedRequest<Book>
            {
                pageNumber = pageNumber,
                totalPages = (int)(Math.Ceiling(result.Count() / (double)pageSize))
            };
            paginatedRequest.Data = await result.Skip((pageNumber - 1) * pageSize).Take(pageSize).ProjectTo<Book>(_mapper.ConfigurationProvider).ToListAsync();
            return paginatedRequest;
        }

        public async Task Update(Book book)
        {
            var entity = await FindBookById(book.Id);
            entity.CategoryId = book.CategoryId;
            entity.Title = book.Title;
            entity.Description = book.Description;
            entity.PublishDateUtc = book.PublishDateUtc;
            await _db.SaveChangesAsync();
        }

        public async Task<Book> GetBookById(long Id)
        {
            return await _db.Books.Where(x => x.Id == Id).ProjectTo<Book>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
