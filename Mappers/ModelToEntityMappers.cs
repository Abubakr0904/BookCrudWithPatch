using SQLite.Entities;
using SQLite.Models;

namespace SQLite.Mappers;

public static class ModelToEntityMappers
{
    public static Book ToEntity(this CreateBookModel model)
    {
        if(model is null)
        {
            return null;
        }

        return new Book
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Title = model.Title
        };
    }

    public static Book ToEntity(this BookModel model)
    {
        if(model is null)
        {
            return null;
        }

        return new Book
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Title = model.Title
        };
    }

    public static Book ToEntity(this BookModel model, Book book)
    {
        if(model is null)
        {
            return null;
        }
        
        return new Book
        {
            Id = book.Id,
            Name = model.Name ?? book.Name,
            Title = model.Title ?? book.Title
        };
    }
}