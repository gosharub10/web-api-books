using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Repositories;

internal class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new();

    public Task<Book> Create(Book entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _books.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<Book>> GetAll(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return Task.FromResult<IEnumerable<Book>>(_books);
    }

    public Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var book = _books.Find(b => b.Id == id);
        return Task.FromResult(book);
    }

    public Task Delete(Book entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var book = _books.Find(b => b.Id == entity.Id);
        if (book != null)
        {
            _books.Remove(book);
        }

        return Task.CompletedTask;
    }

    public Task<Book> Update(Book entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var index = _books.FindIndex(a => a.Id == entity.Id);

        _books[index] = entity;
        return Task.FromResult(entity);
    }
}