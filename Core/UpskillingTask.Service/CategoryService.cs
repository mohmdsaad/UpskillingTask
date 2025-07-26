using AutoMapper;
using UpskillingTask.Domain.Contracts;
using UpskillingTask.Domain.Models;
using UpskillingTask.ServiceAbstraction;
using UpskillingTask.Shared.DataTransferObjects.CategoryDtos;

namespace UpskillingTask.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            var repo = _unitofWork.Repository<Category, int>();
            await repo.AddAsync(category);
            await _unitofWork.CompleteAsync();
            
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var repo = _unitofWork.Repository<Category, int>();
            var categories = await repo.GetAllAsync();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            
            return mappedCategories;
        }

        public async Task<CategoryDto> GetCategoryAsync(int categoryId)
        {
            var repo = _unitofWork.Repository<Category, int>();
            var category = await repo.GetAsync(categoryId);
            if (category == null)
                return null;

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var repo = _unitofWork.Repository<Category, int>();
            var category = await repo.GetAsync(updateCategoryDto.Id);
            if (category == null)
                return null;

            _mapper.Map(updateCategoryDto, category);
            repo.Update(category);
            await _unitofWork.CompleteAsync();
            
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var repo = _unitofWork.Repository<Category, int>();
            var category = await repo.GetAsync(categoryId);
            if (category == null)
                return false;

            repo.Delete(category);
            await _unitofWork.CompleteAsync();
            
            return true;
        }
    }
}
