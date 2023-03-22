using Exhibitopia2.Domain.Entities;

namespace Exhibitopia2.Data.IRepositories;

public interface IPhotoLikeRepository
{
    ValueTask<PhotoLike> InsertAsync(PhotoLike entity);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PhotoLike> UpdateAsync(PhotoLike entity);
    ValueTask<PhotoLike> SelectAsync(long id);
    IQueryable<PhotoLike> SelectAllAsync();
}
