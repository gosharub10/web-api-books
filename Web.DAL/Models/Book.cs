namespace Web.DAL.Models;

public sealed class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int PublishYear { get; set; }
    
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
}