using Exhibitopia2.Data.Contexts;
using Exhibitopia2.Data.IRepositories;
using Exhibitopia2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exhibitopia2.Data.Repositories;

public class PhotoLikeRepository : IPhotoLikeRepository
{
    private AppDbContext DbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        var entity = await DbContext.PhotoLikes.FirstOrDefaultAsync(e => e.Id == id);

        if (entity is null)
        {
            return false;
        }

        DbContext.PhotoLikes.Remove(entity);
        DbContext.SaveChanges();
        return true;
    }

    public async ValueTask<PhotoLike> InsertAsync(PhotoLike entity)
    {
        var insertedEntity = (await DbContext.PhotoLikes.AddAsync(entity)).Entity;
        DbContext.SaveChanges();
        return insertedEntity;
    }

    public IQueryable<PhotoLike> SelectAllAsync()
    {
        return DbContext.PhotoLikes.Where(e => true);
    }

    public async ValueTask<PhotoLike> SelectAsync(long id)
    {
        return await DbContext.PhotoLikes.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async ValueTask<PhotoLike> UpdateAsync(PhotoLike entity)
    {
        if (await DbContext.PhotoLikes.FirstOrDefaultAsync(e => e.Id == entity.Id) is not null)
        {
            var updatedEntity = (DbContext.PhotoLikes.Update(entity)).Entity;
            DbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }
}
