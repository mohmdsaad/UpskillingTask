using UpskillingTask.Shared.DataTransferObjects.BookDtos;

namespace UpskillingTask.ServiceAbstraction
{
    public interface IBookService
    {
        //Retrieve a list of all books.
        Task<IEnumerable<BookDto>> GetAllBooksAsync();

        //Retrieve a specific book by ID.        
        Task<BookDto> GetBookAsync(int bookId);

        //Add a new book. 
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);

        //Update an existing book.
        Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto);

        //Delete a book.
        Task<bool> DeleteBookAsync(int bookId);
    }
}
