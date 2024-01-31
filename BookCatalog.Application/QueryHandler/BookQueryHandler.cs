using AutoMapper;
using BookCatalog.Application.Dtos.Book;
using BookCatalog.Application.Queries.Book;
using BookCatalog.Domain.Common;
using BookCatalog.Domain.Contracts;
using BookCatalog.Domain.Models;
using MediatR;

namespace BookCatalog.Application.QueryHandler
{
    public class BookQueryHandler :
        IRequestHandler<GetAllBooksQuery, PaginatedRequest<BookDto>>,
        IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedRequest<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAll(request.search, request.pageNumber, request.pageSize);
            return _mapper.Map<PaginatedRequest<Book>, PaginatedRequest<BookDto>>(books);
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.id);
            return _mapper.Map<BookDto>(book);
        }
    }
}
