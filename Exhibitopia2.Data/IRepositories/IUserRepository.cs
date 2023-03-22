using Exhibitopia2.Domain.Entities;

public interface IUserRepository
{
    ValueTask<User> InsertAsync(User entity);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<User> UpdateAsync(User entity);
    ValueTask<User> SelectAsync(long id);
    IQueryable<User> SelectAllAsync();
}