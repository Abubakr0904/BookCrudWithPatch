using System.ComponentModel.DataAnnotations;
using SQLite.Models;

namespace SQLite.Entities;
public class Book
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(256)]
    public string Title { get; set; }

    public static explicit operator Book(BookModel model)
    {
        return new Book
        {
            Id = model.Id,
            Name = model.Name,
            Title = model.Title
        };
    }
}