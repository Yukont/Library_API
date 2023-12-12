using Library_API.DAL.Interfaces;
using Library_API.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.DAL.EFUnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LibraryApiContext db;
        BookRepository bookRepository;
        public EFUnitOfWork(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            db = new LibraryApiContext(connectionString);
        }
        public IBookRepository Book
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
