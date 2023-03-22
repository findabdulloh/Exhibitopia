using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;

namespace Exhibitopia2.Service.Interfaces;

public interface IPhotoCommentService
{
    ValueTask<Response<PhotoCommentDto>> AddAsync(PhotoCommentCreationDto model);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<PhotoCommentDto>> UpdateAsync(long id, string text);
    ValueTask<Response<List<PhotoCommentDto>>> GetAllByPhotoIdAsync(long id);
    ValueTask<Response<List<PhotoCommentDto>>> GetAllByUserIdAsync(long id);
}