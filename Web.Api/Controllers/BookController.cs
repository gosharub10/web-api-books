using Microsoft.AspNetCore.Mvc;
using Web.BLL.DTOs.Books;
using Web.BLL.Interfaces;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBook book, CancellationToken cancellationToken)
    {
        var newBook = await _bookService.AddBook(book, cancellationToken);

        return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var books = await _bookService.GetAllBooks(cancellationToken);

        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBook(Guid id, CancellationToken cancellationToken)
    {
        var book = await _bookService.GetBookById(id, cancellationToken);

        return Ok(book);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBook book,
        CancellationToken cancellationToken)
    {
        var update = await _bookService.UpdateBook(id, book, cancellationToken);

        return Ok(update);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBook(Guid id, CancellationToken cancellationToken)
    {
        await _bookService.DeleteBook(id, cancellationToken);

        return NoContent();
    }

    [HttpGet("published-after")]
    public async Task<IActionResult> GetPublishedAfterYear([FromQuery] int year, CancellationToken cancellationToken)
    {
        var books = await _bookService.GetBooksPublishedAfterYear(year, cancellationToken);
        
        return Ok(books);
    }
}