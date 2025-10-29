using Microsoft.EntityFrameworkCore;
using Web.DAL.Context;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Repositories;

internal class BookRepository(LibraryContext context) : IBookRepository
{
    private readonly LibraryContext  _context = context;

    public async Task<Book> Create(Book entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        await _context.Books.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity;
    }

    public async Task<IEnumerable<Book>> GetAll(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await _context.Books
            .Include(a => a.Author)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _context.Books
            .Include(a => a.Author)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task Delete(Book entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var existingEntity = await _context.Books.FirstOrDefaultAsync(b => b.Id == entity.Id, cancellationToken);
        if (existingEntity != null)
        {
            _context.Books.Remove(existingEntity);
        }
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Book> Update(Book entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        _context.Books.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity;
    }
}