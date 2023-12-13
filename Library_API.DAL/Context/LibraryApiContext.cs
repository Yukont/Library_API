using Library_API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_API.DAL.Context;

public partial class LibraryApiContext : DbContext
{
    public LibraryApiContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public LibraryApiContext(DbContextOptions<LibraryApiContext> options)
        : base(options)
    {
    }

    public string ConnectionString { get; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Isbn).HasMaxLength(13);
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
