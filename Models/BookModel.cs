using SQLite.Entities;

namespace SQLite.Models;

public class BookModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }

    public static explicit operator BookModel(Book entity)
    {
        return new BookModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Title = entity.Title
        };
    }
}