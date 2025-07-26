using System.ComponentModel.DataAnnotations;

namespace UpskillingTask.Shared.DataTransferObjects.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}
