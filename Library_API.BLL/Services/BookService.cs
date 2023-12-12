using AutoMapper;
using Library_API.BLL.DTO;
using Library_API.BLL.Interfaces;
using Library_API.DAL.Entities;
using Library_API.DAL.Interfaces;

namespace Library_API.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddBook(BookDTO bookDto)
        {
            Book book = mapper.Map<BookDTO, Book>(bookDto);

            await unitOfWork.Book.CreateAsync(book);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<BookDTO> GetBookById(int bookId)
        {
            Book book = await unitOfWork.Book.GetAsync(bookId);

            BookDTO bookDto = mapper.Map<Book, BookDTO>(book);
            return bookDto;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBook()
        {
            IEnumerable<Book> book = await unitOfWork.Book.GetAllAsync();
            return mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(book);
        }

        public async Task RemoveBook(int bookId)
        {
            Book book = await unitOfWork.Book.GetAsync(bookId);

            await unitOfWork.Book.DeleteAsync(bookId);
            unitOfWork.Save();
        }

        public async Task UpdateBook(BookDTO bookDto)
        {
            Book updatedBook = mapper.Map<BookDTO, Book>(bookDto);

            await unitOfWork.Book.UpdateAsync(updatedBook);
            unitOfWork.Save();
        }

        public async Task<BookDTO> GetBookByISBN(string bookId)
        {
            Book book = await unitOfWork.Book.GetByISBNAsync(bookId);
            BookDTO bookDto = mapper.Map<Book, BookDTO>(book);
            return bookDto;
        }
    }
}
