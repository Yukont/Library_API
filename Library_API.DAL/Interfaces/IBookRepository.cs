using Library_API.DAL.Entities;

namespace Library_API.DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetByISBNAsync(string id);
    }
}
