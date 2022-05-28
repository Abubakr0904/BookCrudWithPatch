using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SQLite.Entities;
using SQLite.Mappers;
using SQLite.Models;
using SQLite.Services;

namespace SQLite.Controller;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IEnumerable<BookModel>> GetAllAsync()
        => (await _bookService.GetAllAsync()).Select(book => book.ToModel());

    [HttpGet("{id}")]
    public async Task<BookModel> GetByIdAsync(Guid id)
        => (await _bookService.GetByIdAsync(id)).ToModel();

    [HttpPost("create")]
    public async Task AddAsync(CreateBookModel newBook)
        => await _bookService.AddAsync(newBook.ToEntity());

    [HttpDelete("delete/{id}")]
    public async Task DeleteAsync(Guid id)
        => await _bookService.DeleteAsync(id);
    
    [HttpPut("update/{id}")]
    public async Task UpdateAsync(Guid id, BookModel book)
        => await _bookService.UpdateAsync(book.ToEntity());

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]JsonPatchDocument<Book> patch)
    {
        var entity = await _bookService.GetByIdAsync(id);
        var original = entity.Copy();
        patch.ApplyTo(entity, ModelState);

        var isValid = TryValidateModel(entity);
        if (!isValid)
        {
            return BadRequest(ModelState);
        }

        await _bookService.UpdateAsync(entity);
        var result = new
        {
            Original = original.ToModel(),
            Updated = entity.ToModel()
        };

        return Ok(result);
    }
}