using Microsoft.EntityFrameworkCore;
using SQLite.Entities;

namespace SQLite.Services;
public class BookService : IBookService
{
    private readonly ILogger<BookService> _logger;
    private readonly BookDbContext _context;

    public BookService(ILogger<BookService> logger, BookDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task AddAsync(Book newBook)
    {
        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await GetByIdAsync(id);
        if (book == null)
        {
            _logger.LogWarning("Book with id {id} not found", id);
            return;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllAsync()
        => await _context.Books.ToListAsync();

    public async Task<Book> GetByIdAsync(Guid id)
         => _context.Books.FirstOrDefault(b => b.Id == id);

    public async Task UpdateAsync(Book book)
    {
        var bookToUpdate = await GetByIdAsync(book.Id);
        bookToUpdate.Name = book.Name;
        bookToUpdate.Title = book.Title;
        
        await _context.SaveChangesAsync();
    }
}