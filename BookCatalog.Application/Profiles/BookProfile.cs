using AutoMapper;
using BookCatalog.Application.Commands.Book;
using BookCatalog.Application.Dtos.Book;
using BookCatalog.Domain.Common;
using BookCatalog.Domain.Models;
using dbEntity = BookCatalog.Infrastructure.Database.Entities;

namespace BookCatalog.Domain.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap(typeof(PaginatedRequest<>), typeof(PaginatedRequest<>));
            CreateMap<CreateBookDto, CreateBookCommand>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookDto, UpdateBookCommand>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<Book, dbEntity.Book>().ReverseMap();
            //CreateMap<PaginatedRequest<Book>, PaginatedRequest<BookDto>>().
            //    ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.Data));
        }
    }
}
