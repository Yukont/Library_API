using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library_API;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mssql-157393-0.cloudclusters.net,18177;Initial Catalog=Library_API;User ID=Lera;Password=Llera3321;Connect Timeout=30;Encrypt=True;Application Intent=ReadWrite;Multi Subnet Failover=False;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
