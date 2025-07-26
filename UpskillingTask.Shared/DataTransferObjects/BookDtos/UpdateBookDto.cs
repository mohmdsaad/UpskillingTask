using System.ComponentModel.DataAnnotations;

namespace UpskillingTask.Shared.DataTransferObjects.BookDtos
{
    public class UpdateBookDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Auther { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
