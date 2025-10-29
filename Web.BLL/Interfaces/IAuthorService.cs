using Web.BLL.DTOs.Author;
using Web.DAL.Models;

namespace Web.BLL.Interfaces;

public interface IAuthorService
{
    Task<GetAuthor> AddAuthor(CreateAuthor author, CancellationToken cancellationToken);
    Task<IEnumerable<GetAuthor>> GetAllAuthors(CancellationToken cancellationToken);
    Task<GetAuthor> GetAuthorById(Guid id, CancellationToken cancellationToken);
    Task<GetAuthor> UpdateAuthor(Guid id, UpdateAuthor author, CancellationToken cancellationToken);
    Task DeleteAuthor(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<GetAuthorsWithBookCount>> GetAuthorsWithBookCount(CancellationToken cancellationToken); 
    Task<IEnumerable<GetAuthor>> GetAuthorByName(string name, CancellationToken cancellationToken);
}