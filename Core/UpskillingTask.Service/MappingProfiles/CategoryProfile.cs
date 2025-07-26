using AutoMapper;
using UpskillingTask.Domain.Models;
using UpskillingTask.Shared.DataTransferObjects.CategoryDtos;

namespace UpskillingTask.Service.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
