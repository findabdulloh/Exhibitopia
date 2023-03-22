using Exhibitopia2.Data.Contexts;
using Exhibitopia2.Data.IRepositories;
using Exhibitopia2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exhibitopia2.Data.Repositories;

public class PhotoCommentRepository : IPhotoCommentRepository
{
    private AppDbContext DbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        var entity = await DbContext.PhotoComments.FirstOrDefaultAsync(e => e.Id == id);

        if (entity is null)
        {
            return false;
        }

        DbContext.PhotoComments.Remove(entity);
        DbContext.SaveChanges();
        return true;
    }

    public async ValueTask<PhotoComment> InsertAsync(PhotoComment entity)
    {
        var insertedEntity = (await DbContext.PhotoComments.AddAsync(entity)).Entity;
        DbContext.SaveChanges();
        return insertedEntity;
    }

    public IQueryable<PhotoComment> SelectAllAsync()
    {
        return DbContext.PhotoComments.Where(e => true);
    }

    public async ValueTask<PhotoComment> SelectAsync(long id)
    {
        return await DbContext.PhotoComments.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async ValueTask<PhotoComment> UpdateAsync(PhotoComment entity)
    {
        if (await DbContext.PhotoComments.FirstOrDefaultAsync(e => e.Id == entity.Id) is not null)
        {
            var updatedEntity = (DbContext.PhotoComments.Update(entity)).Entity;
            DbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }
}
