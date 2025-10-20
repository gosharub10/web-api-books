namespace Web.BLL.DTOs.Books;

public sealed record CreateBook
{
    public string Title { get; init; }
    public int PublishYear { get; init; }
    public Guid AuthorId { get; init; }
}