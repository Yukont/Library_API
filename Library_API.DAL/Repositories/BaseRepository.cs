using Library_API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_API.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext dbContext;

        internal BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(T item)
        {
            await dbContext.Set<T>().AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await dbContext.Set<T>().FindAsync(id);
            if (item != null)
            {
                dbContext.Set<T>().Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            return await Task.FromResult(dbContext.Set<T>().Where(predicate).ToList());
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");
            }
            return entity;
        }

        public async Task UpdateAsync(T item)
        {
            dbContext.Set<T>().Update(item);
            await dbContext.SaveChangesAsync();
        }
    }
}
