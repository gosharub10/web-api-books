using AutoMapper;
using Web.BLL.DTOs.Author;
using Web.BLL.Interfaces;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.BLL.Services;

internal class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<GetAuthor> AddAuthor(CreateAuthor author, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(author);
        ArgumentException.ThrowIfNullOrWhiteSpace(author.Name);

        
        
        var newAuthor = _mapper.Map<Author>(author);
        newAuthor.Id = Guid.NewGuid();

        var result = await _authorRepository.Create(newAuthor, cancellationToken);

        return _mapper.Map<GetAuthor>(result);
    }

    public async Task<IEnumerable<GetAuthor>> GetAllAuthors(CancellationToken cancellationToken)
    {
        var result = await _authorRepository.GetAll(cancellationToken);

        return _mapper.Map<IEnumerable<GetAuthor>>(result);
    }

    public async Task<GetAuthor> GetAuthorById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _authorRepository.GetByIdAsync(id, cancellationToken) ??
                     throw new KeyNotFoundException("Author not found");

        return _mapper.Map<GetAuthor>(result);
    }

    public async Task<GetAuthor> UpdateAuthor(Guid id, UpdateAuthor author, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(author);
        ArgumentException.ThrowIfNullOrWhiteSpace(author.Name);

        _ = await _authorRepository.GetByIdAsync(id, cancellationToken) ??
            throw new KeyNotFoundException("Author not found");

        var updatedAuthor = _mapper.Map<Author>(author);
        updatedAuthor.Id = id;

        var result = await _authorRepository.Update(updatedAuthor, cancellationToken);

        return _mapper.Map<GetAuthor>(result);
    }

    public async Task DeleteAuthor(Guid id, CancellationToken cancellationToken)
    {
        var finded = await _authorRepository.GetByIdAsync(id, cancellationToken) ??
                     throw new KeyNotFoundException("Author not found");

        await _authorRepository.Delete(finded, cancellationToken);
    }

    public async Task<IEnumerable<GetAuthorsWithBookCount>> GetAuthorsWithBookCount(CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAll(cancellationToken);
        
        var authorsWithBookCount = authors.Select(a =>
            new GetAuthorsWithBookCount
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                BookCount = a.Books.Count
            }
        );
        
        return authorsWithBookCount;
    }

    public async Task<IEnumerable<GetAuthor>> GetAuthorByName(string name, CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAll(cancellationToken);

        var findedAuthor = authors.Where(a => a.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToList();
        
        return _mapper.Map<IEnumerable<GetAuthor>>(findedAuthor);
    }
}