using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;

namespace Exhibitopia2.Service.Interfaces;

public interface IPhotoService
{
    ValueTask<Response<PhotoDto>> AddAsync(PhotoCreationDto model);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<PhotoDto>> UpdateAsync(long id, PhotoCreationDto model);
    ValueTask<Response<PhotoDto>> GetByIdAsync(long id);
    ValueTask<Response<List<PhotoDto>>> GetAllAsync();
}
