using UpskillingTask.Shared.DataTransferObjects.CategoryDtos;

namespace UpskillingTask.ServiceAbstraction
{
    public interface ICategoryService
    {
        //Retrieve a list of all categories.
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        //Retrieve a specific category by ID.
        Task<CategoryDto> GetCategoryAsync(int categoryId);

        //Create a new category.
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        //Update an existing category.
        Task<CategoryDto> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        //Delete a category.
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
