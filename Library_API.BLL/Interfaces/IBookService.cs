using Library_API.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.Interfaces
{
    public interface IBookService : IDisposable
    {
        Task AddBook(BookDTO bookDto);
        Task UpdateBook(BookDTO bookDto);
        Task RemoveBook(int bookId);
        Task<BookDTO> GetBookById(int bookId);
        Task<IEnumerable<BookDTO>> GetAllBook();
    }
}
