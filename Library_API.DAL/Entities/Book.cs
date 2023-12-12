namespace Library_API.DAL.Entities;

public partial class Book
{
    public int Id { get; set; }

    public int Isbn { get; set; }

    public string Name { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateOnly TakingTime { get; set; }

    public DateOnly ReturnTime { get; set; }
}
