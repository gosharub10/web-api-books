namespace Web.BLL.DTOs.Books;

public sealed record GetBook
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public int PublishYear { get; init; }
    public Guid AuthorId { get; init; }
}