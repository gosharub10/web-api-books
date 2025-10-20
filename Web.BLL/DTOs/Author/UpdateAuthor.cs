namespace Web.BLL.DTOs.Author;

public sealed record UpdateAuthor
{
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
}