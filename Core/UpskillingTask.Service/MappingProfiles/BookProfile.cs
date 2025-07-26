using AutoMapper;
using UpskillingTask.Domain.Models;
using UpskillingTask.Shared.DataTransferObjects.BookDtos;

namespace UpskillingTask.Service.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                        .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)); 
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
}
