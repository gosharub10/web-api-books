using Microsoft.AspNetCore.Mvc;
using Web.BLL.DTOs.Author;
using Web.BLL.Interfaces;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthor author, CancellationToken cancellationToken)
    {
        var newAuthor = await _authorService.AddAuthor(author, cancellationToken);

        return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, newAuthor);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAuthors(CancellationToken cancellationToken)
    {
        var authors = await _authorService.GetAllAuthors(cancellationToken);

        return Ok(authors);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAuthor(Guid id, CancellationToken cancellationToken)
    {
        var author = await _authorService.GetAuthorById(id, cancellationToken);

        return Ok(author);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] UpdateAuthor author,
        CancellationToken cancellationToken)
    {
        var updated = await _authorService.UpdateAuthor(id, author, cancellationToken);

        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAuthor(Guid id, CancellationToken cancellationToken)
    {
        await _authorService.DeleteAuthor(id, cancellationToken);

        return NoContent();
    }

    [HttpGet("count/book")]
    public async Task<IActionResult> GetAuthorsWithBookCount(CancellationToken cancellationToken)
    {
        var authors = await _authorService.GetAuthorsWithBookCount(cancellationToken);
        
        return Ok(authors);
    }

    [HttpGet("search/{name}")]
    public async Task<IActionResult> GetAuthorByName(string name, CancellationToken cancellationToken)
    {
        var authors = await _authorService.GetAuthorByName(name, cancellationToken);
        
        return Ok(authors);
    }
}