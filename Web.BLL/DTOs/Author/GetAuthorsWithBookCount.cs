namespace Web.BLL.DTOs.Author;

public record GetAuthorsWithBookCount
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
    public int BookCount { get; init; }
}