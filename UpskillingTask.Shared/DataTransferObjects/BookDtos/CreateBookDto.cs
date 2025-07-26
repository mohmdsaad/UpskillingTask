using System.ComponentModel.DataAnnotations;

namespace UpskillingTask.Shared.DataTransferObjects.BookDtos
{
    public class CreateBookDto
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Auther { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative.")]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
