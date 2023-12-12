using Library_API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.DAL.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        internal BookRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
