using SQLite.Entities;

namespace SQLite.Mappers;

public static class AdditionalMappers
{
    public static Book Copy(this Book entity)
    {
        if(entity == null)
        {
            return null;
        }
        
        return new Book
        {
            Id = entity.Id,
            Name = entity.Name,
            Title = entity.Title
        };
    }
}