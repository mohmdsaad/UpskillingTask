using AutoMapper;
using UpskillingTask.Domain.Contracts;
using UpskillingTask.Domain.Models;
using UpskillingTask.ServiceAbstraction;
using UpskillingTask.Shared.DataTransferObjects.BookDtos;

namespace UpskillingTask.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public BookService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<CreateBookDto, Book>(createBookDto);
            var repo = _unitofWork.Repository<Book, int>();
            await repo.AddAsync(book);

            await _unitofWork.CompleteAsync();

            //get book including the category
            var bookWithCategory = await repo.GetByConditionAsync(
                                        b => b.Id == book.Id,
                                        b => b.Category
                                    );

            return _mapper.Map<BookDto>(bookWithCategory);
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var repo = _unitofWork.Repository<Book, int>();
            var books = await repo.GetListByConditionAsync(
                b => true,              //get all books
                b => b.Category         //include Category
            );

            var mappedBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return mappedBooks;
        }

        public async Task<BookDto> GetBookAsync(int bookId)
        {
            var repo = _unitofWork.Repository<Book, int>();
            var book = await repo.GetByConditionAsync(
                                        b => b.Id == bookId,
                                        b => b.Category
                                    );
            if (book == null) 
                return null;

            var mappedBook = _mapper.Map<Book,BookDto>(book);

            return mappedBook;
        }

        public async Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var repo = _unitofWork.Repository<Book, int>();
            var book = await repo.GetAsync(updateBookDto.Id);
            if (book == null)
                return null;

            _mapper.Map(updateBookDto, book);
            repo.Update(book);
            await _unitofWork.CompleteAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var repo = _unitofWork.Repository<Book, int>();
            var book = await repo.GetAsync(bookId);

            if (book == null) 
                return false;

            repo.Delete(book);
            await _unitofWork.CompleteAsync();

            return true;
        }
    }
}
