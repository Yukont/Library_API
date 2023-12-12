using Library_API.DAL.Entities;
using Library_API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_API.DAL.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        internal BookRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
