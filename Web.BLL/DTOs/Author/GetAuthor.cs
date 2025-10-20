namespace Web.BLL.DTOs.Author;

public sealed record GetAuthor
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
}