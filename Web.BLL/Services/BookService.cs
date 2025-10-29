using AutoMapper;
using Web.BLL.DTOs.Books;
using Web.BLL.Interfaces;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.BLL.Services;

internal class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<GetBook> AddBook(CreateBook book, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(book);
        ArgumentException.ThrowIfNullOrWhiteSpace(book.Title);
        ArgumentException.ThrowIfNullOrWhiteSpace(book.PublishYear.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(book.AuthorId.ToString());

        _ = await _authorRepository.GetByIdAsync(book.AuthorId, cancellationToken) ?? throw new KeyNotFoundException("Author not found");
        
        var newBook = _mapper.Map<Book>(book);
        newBook.Id = Guid.NewGuid();

        var result = await _bookRepository.Create(newBook, cancellationToken);

        return _mapper.Map<GetBook>(result);
    }

    public async Task<IEnumerable<GetBook>> GetAllBooks(CancellationToken cancellationToken)
    {
        var result = await _bookRepository.GetAll(cancellationToken);

        return _mapper.Map<IEnumerable<GetBook>>(result);
    }

    public async Task<GetBook> GetBookById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _bookRepository.GetByIdAsync(id, cancellationToken) ??
                     throw new KeyNotFoundException("Book not found");

        return _mapper.Map<GetBook>(result);
    }

    public async Task<GetBook> UpdateBook(Guid id, UpdateBook book, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(book);
        ArgumentException.ThrowIfNullOrWhiteSpace(book.Title);
        ArgumentException.ThrowIfNullOrWhiteSpace(book.PublishYear.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(book.AuthorId.ToString());
        
        _ = await _authorRepository.GetByIdAsync(book.AuthorId, cancellationToken) ?? throw new KeyNotFoundException("Author not found");

        _ = await _bookRepository.GetByIdAsync(id, cancellationToken) ??
            throw new KeyNotFoundException("Book not found");

        var updatedBook = _mapper.Map<Book>(book);
        updatedBook.Id = id;

        var result = await _bookRepository.Update(updatedBook, cancellationToken);

        return _mapper.Map<GetBook>(result);
    }

    public async Task DeleteBook(Guid id, CancellationToken cancellationToken)
    {
        var finded = await _bookRepository.GetByIdAsync(id, cancellationToken) ??
                     throw new KeyNotFoundException("Book not found");

        await _bookRepository.Delete(finded, cancellationToken);
    }

    public async Task<IEnumerable<GetBook>> GetBooksPublishedAfterYear(int year, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAll(cancellationToken);
        
        var bookAfterYear =  books.Where(b => b.PublishYear >= year);
        
        return _mapper.Map<IEnumerable<GetBook>>(bookAfterYear);
    }
}