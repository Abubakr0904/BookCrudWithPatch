using SQLite.Entities;

namespace SQLite.Models;

public class CreateBookModel
{
    public string Name { get; set; }
    public string Title { get; set; }

    public static explicit operator Book(CreateBookModel entity)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Name = entity.Name,
            Title = entity.Title
        };
    }
}