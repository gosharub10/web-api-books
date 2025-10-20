using Web.BLL.DTOs.Books;
using Web.DAL.Models;

namespace Web.BLL.Interfaces;

public interface IBookService
{
    Task<GetBook> AddBook(CreateBook book, CancellationToken cancellationToken);
    Task<IEnumerable<GetBook>> GetAllBooks(CancellationToken cancellationToken);
    Task<GetBook> GetBookById(Guid id, CancellationToken cancellationToken);
    Task<GetBook> UpdateBook(Guid id, UpdateBook book, CancellationToken cancellationToken);
    Task DeleteBook(Guid id, CancellationToken cancellationToken);
}