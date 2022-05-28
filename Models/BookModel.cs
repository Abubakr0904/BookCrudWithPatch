using SQLite.Entities;

namespace SQLite.Models;

public class BookModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
}