namespace UpskillingTask.Shared.DataTransferObjects.BookDtos
{
    public class BookDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Auther { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; } = default!;
    }
}