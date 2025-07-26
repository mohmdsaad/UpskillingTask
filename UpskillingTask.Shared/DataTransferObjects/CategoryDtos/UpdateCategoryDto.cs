using System.ComponentModel.DataAnnotations;

namespace UpskillingTask.Shared.DataTransferObjects.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
