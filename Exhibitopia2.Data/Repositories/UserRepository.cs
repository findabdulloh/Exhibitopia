using Exhibitopia2.Data.Contexts;
using Exhibitopia2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exhibitopia2.Data.Repositories;

public class UserRepository : IUserRepository
{
    private AppDbContext DbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        var entity = await DbContext.Users.FirstOrDefaultAsync(e => e.Id == id);

        if (entity is null)
        {
            return false;
        }

        DbContext.Users.Remove(entity);
        DbContext.SaveChanges();
        return true;
    }

    public async ValueTask<User> InsertAsync(User entity)
    {
        var insertedEntity = (await DbContext.Users.AddAsync(entity)).Entity;
        DbContext.SaveChanges();
        return insertedEntity;
    }

    public IQueryable<User> SelectAllAsync()
    {
        return DbContext.Users.Where(e => true);
    }

    public async ValueTask<User> SelectAsync(long id)
    {
        return await DbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async ValueTask<User> UpdateAsync(User entity)
    {
        if (await DbContext.Users.FirstOrDefaultAsync(e => e.Id == entity.Id) is not null)
        {
            var updatedEntity = (DbContext.Users.Update(entity)).Entity;
            DbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }
}
