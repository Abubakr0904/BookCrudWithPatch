using SQLite.Entities;
using SQLite.Models;

namespace SQLite.Mappers;

public static class EntityToModelMappers
{
    public static BookModel ToModel(this Book entity)
    {
        if(entity == null)
        {
            return null;
        }
        
        return new BookModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Title = entity.Title
        };
    }
}