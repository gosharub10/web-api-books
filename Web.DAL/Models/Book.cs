namespace Web.DAL.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublishYear { get; set; }
    public int AuthorId { get; set; }
}