namespace Web.DAL.Models;

public sealed class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}