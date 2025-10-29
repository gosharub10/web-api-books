using Microsoft.EntityFrameworkCore;
using Web.DAL.Context;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Repositories;

internal class AuthorRepository(LibraryContext context) : IAuthorRepository
{
    private readonly LibraryContext _context = context;

    public async Task<Author> Create(Author entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await _context.Authors.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<Author>> GetAll(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _context.Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task Delete(Author entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var existingEntity = _context.Authors.FirstOrDefault(a => a.Id == entity.Id);
        if (existingEntity != null)
        {
            _context.Authors.Remove(existingEntity);
        }
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Author> Update(Author entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _context.Authors.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity;
    }
}