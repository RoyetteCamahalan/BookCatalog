using AutoMapper;
using BookCatalog.api.Common;
using BookCatalog.Application.Commands.Book;
using BookCatalog.Application.Dtos.Book;
using BookCatalog.Application.Queries.Book;
using BookCatalog.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCatalog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, int pageNumber, int pageSize)
        {
            return await Handle<PaginatedRequest<BookDto>>(new GetAllBooksQuery(search ?? "", pageNumber, pageSize));
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await Handle<BookDto>(new GetBookByIdQuery(id));
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
        {
            return await Handle<CreateBookDto, CreateBookCommand, long>(dto);
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto dto)
        {
            return await Handle<UpdateBookDto, UpdateBookCommand, object>(dto);
        }
    }
}
