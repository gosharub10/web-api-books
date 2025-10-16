using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Repositories;

internal class AuthorRepository : IAuthorRepository
{
    private readonly List<Author> _authors = [];

    public Task<Author> Create(Author entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _authors.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<Author>> GetAll(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult<IEnumerable<Author>>(_authors);
    }

    public  Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var author = _authors.Find(a => a.Id == id);
        return Task.FromResult(author);
    }

    public Task Delete(Author entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var author = _authors.Find(a => a.Id == entity.Id);
        if (author != null)
        {
            _authors.Remove(author);
        }

        return Task.CompletedTask;
    }

    public Task<Author> Update(Author entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var index = _authors.FindIndex(a => a.Id == entity.Id);
        if (index == -1)
        {
            throw new KeyNotFoundException($"Author {entity.Id} not found.");
        }

        _authors[index] = entity;
        return Task.FromResult(entity);
    }
}