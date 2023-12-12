namespace Library_API.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Book { get; }
        void Save();
    }
}
