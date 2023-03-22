using Exhibitopia2.Data.Contexts;
using Exhibitopia2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exhibitopia2.Data.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private AppDbContext DbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        var entity = await DbContext.Photos.FirstOrDefaultAsync(e => e.Id == id);

        if (entity is null)
        {
            return false;
        }

        DbContext.Photos.Remove(entity);
        DbContext.SaveChanges();
        return true;
    }

    public async ValueTask<Photo> InsertAsync(Photo entity)
    {
        var insertedEntity = (await DbContext.Photos.AddAsync(entity)).Entity;
        DbContext.SaveChanges();
        return insertedEntity;
    }

    public IQueryable<Photo> SelectAllAsync()
    {
        return DbContext.Photos.Where(e => true);
    }

    public async ValueTask<Photo> SelectAsync(long id)
    {
        return await DbContext.Photos.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async ValueTask<Photo> UpdateAsync(Photo entity)
    {
        if (await DbContext.Photos.FirstOrDefaultAsync(e => e.Id == entity.Id) is not null)
        {
            var updatedEntity = (DbContext.Photos.Update(entity)).Entity;
            DbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }
}
