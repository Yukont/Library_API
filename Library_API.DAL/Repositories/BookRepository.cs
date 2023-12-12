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

        public async Task<Book> GetByISBNAsync(string isbn)
        {
            var entity = await dbContext.Set<Book>().SingleOrDefaultAsync(a => a.Isbn.Equals(isbn));

            if (entity == null)
            {
                throw new KeyNotFoundException($"Book with ISBN {isbn} not found.");
            }

            return entity;
        }

    }
}
