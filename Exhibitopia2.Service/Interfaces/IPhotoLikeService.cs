using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;

namespace Exhibitopia2.Service.Interfaces;

public interface IPhotoLikeService
{
    ValueTask<Response<PhotoLikeDto>> AddLikeAsync(long userId, long photoId);
    ValueTask<Response<bool>> DeleteLikeAsync(long userId, long photoId);
    ValueTask<Response<List<PhotoLikeDto>>> GetAllLikesOfUserAsync(long userId);
    ValueTask<Response<List<PhotoLikeDto>>> GetAllLikesOfProjectAsync(long projectId);
}