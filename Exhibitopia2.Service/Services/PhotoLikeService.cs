using Exhibitopia2.Data.IRepositories;
using Exhibitopia2.Data.Repositories;
using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;
using Exhibitopia2.Service.Interfaces;

namespace Exhibitopia2.Service.Services;

public class PhotoLikeService : IPhotoLikeService
{
    private IPhotoLikeRepository photoLikeRepository = new PhotoLikeRepository();
    private IPhotoService photoService = new PhotoService();
    private IUserService userService = new UserService();

    public async ValueTask<Response<PhotoLikeDto>> AddLikeAsync(long userId, long photoId)
    {
        var user = (await userService.GetByIdAsync(userId)).Value;
        var photo = (await photoService.GetByIdAsync(photoId)).Value;
        if (user is null || photo is null)
            return new Response<PhotoLikeDto>
            {
                StatusCode = 404,
                Message = "Not found user or project"
            };

        var newEntity = new PhotoLike
        {
            CreatedAt = DateTime.Now,
            PhotoId = photoId,
            UserId = userId
        };

        var insertedEntity = await photoLikeRepository.InsertAsync(newEntity);

        var mappedDto = new PhotoLikeDto
        {
            CreatedAt = insertedEntity.CreatedAt,
            Photo = photo,
            User = user,
            Id = insertedEntity.Id
        };

        return new Response<PhotoLikeDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<bool>> DeleteLikeAsync(long userId, long photoId)
    {
        var existedEntity = photoLikeRepository.SelectAllAsync()
                            .Where(u => u.UserId == userId && u.PhotoId == photoId).Take(1)
                            .ToList().FirstOrDefault();

        if (existedEntity is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        await photoLikeRepository.DeleteAsync(existedEntity.Id);

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<PhotoLikeDto>>> GetAllLikesOfProjectAsync(long photoId)
    {
        var entities = photoLikeRepository.SelectAllAsync()
                            .Where(u => u.PhotoId == photoId).ToList();

        var mappedModels = new List<PhotoLikeDto>();

        foreach (var entity in entities)
        {
            mappedModels.Add(new PhotoLikeDto
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
                Photo = (await photoService.GetByIdAsync(entity.PhotoId)).Value,
                UpdatedAt = entity.UpdatedAt,
                User = (await userService.GetByIdAsync(entity.UserId)).Value,
            });
        }

        return new Response<List<PhotoLikeDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedModels
        };
    }

    public async ValueTask<Response<List<PhotoLikeDto>>> GetAllLikesOfUserAsync(long userId)
    {
        var entities = photoLikeRepository.SelectAllAsync()
                            .Where(u => u.UserId == userId).ToList();
        var mappedModels = new List<PhotoLikeDto>();

        foreach (var entity in entities)
        {
            mappedModels.Add(new PhotoLikeDto
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
                Photo = (await photoService.GetByIdAsync(entity.PhotoId)).Value,
                UpdatedAt = entity.UpdatedAt,
                User = (await userService.GetByIdAsync(entity.UserId)).Value,
            });
        }

        return new Response<List<PhotoLikeDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedModels
        };
    }
}