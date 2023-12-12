using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.DAL.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IBookRepository Book { get; }
        void Save();
    }
}
