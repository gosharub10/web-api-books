namespace Web.BLL.DTOs.Books;

public sealed record UpdateBook
{
    public string Title { get; init; }
    public int PublishYear { get; init; }
    public Guid AuthorId { get; init; }
}