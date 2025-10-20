namespace Web.BLL.DTOs.Author;

public sealed record CreateAuthor
{
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
}