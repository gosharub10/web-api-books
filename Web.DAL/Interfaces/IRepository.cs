using Web.DAL.Models;

namespace Web.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> Create(T entity, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task Delete(T entity, CancellationToken cancellationToken);
    Task<T> Update(T entity, CancellationToken cancellationToken);
}