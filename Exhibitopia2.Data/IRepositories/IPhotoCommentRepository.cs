using Exhibitopia2.Domain.Entities;

namespace Exhibitopia2.Data.IRepositories;

public interface IPhotoCommentRepository
{
    ValueTask<PhotoComment> InsertAsync(PhotoComment entity);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PhotoComment> UpdateAsync(PhotoComment entity);
    ValueTask<PhotoComment> SelectAsync(long id);
    IQueryable<PhotoComment> SelectAllAsync();
}
