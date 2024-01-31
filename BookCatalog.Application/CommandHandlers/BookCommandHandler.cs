using AutoMapper;
using BookCatalog.Application.Commands.Book;
using BookCatalog.Domain.Contracts;
using BookCatalog.Domain.Models;
using MediatR;

namespace BookCatalog.Application.CommandHandlers
{
    public class BookCommandHandler :
        IRequestHandler<CreateBookCommand, long>,
        IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            return await _bookRepository.Add(book);
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookRepository.Update(book);
            return new Unit();
        }
    }
}
