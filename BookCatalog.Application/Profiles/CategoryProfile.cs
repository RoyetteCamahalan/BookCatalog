using AutoMapper;
using BookCatalog.Application.Dtos.Category;
using BookCatalog.Domain.Models;
using dbEntity = BookCatalog.Infrastructure.Database.Entities;

namespace BookCatalog.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, dbEntity.Category>().ReverseMap();
        }
    }
}
