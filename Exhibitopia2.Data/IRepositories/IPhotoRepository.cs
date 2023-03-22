using Exhibitopia2.Domain.Entities;

public interface IPhotoRepository
{
        ValueTask<Photo> InsertAsync(Photo entity);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<Photo> UpdateAsync(Photo entity);
        ValueTask<Photo> SelectAsync(long id);
        IQueryable<Photo> SelectAllAsync();
}