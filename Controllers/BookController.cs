using Microsoft.AspNetCore.Mvc;
using SQLite.Entities;
using SQLite.Models;
using SQLite.Services;

namespace SQLite.Controller;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IEnumerable<BookModel>> GetAllAsync()
        => (await _bookService.GetAllAsync()).Select(book => (BookModel)book);

    [HttpGet("{id}")]
    public async Task<BookModel> GetByIdAsync(Guid id)
        => (BookModel) await _bookService.GetByIdAsync(id);

    [HttpPost("create")]
    public async Task AddAsync(CreateBookModel newBook)
        => await _bookService.AddAsync((Book) newBook);

    [HttpDelete("delete/{id}")]
    public async Task DeleteAsync(Guid id)
        => await _bookService.DeleteAsync(id);
    
    [HttpPut("update/{id}")]
    public async Task UpdateAsync(Guid id, BookModel book)
        => await _bookService.UpdateAsync((Book) book);
}