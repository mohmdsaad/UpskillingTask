namespace UpskillingTask.Domain.Models
{
    public class Book : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Auther { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Category Category  { get; set; }
        public int CategoryId { get; set; }
    }
}