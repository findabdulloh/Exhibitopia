using Exhibitopia2.Data.IRepositories;
using Exhibitopia2.Data.Repositories;
using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;
using Exhibitopia2.Service.Interfaces;

namespace Exhibitopia2.Service.Services;

public class PhotoCommentService : IPhotoCommentService
{
    private IPhotoCommentRepository photoCommentRepository = new PhotoCommentRepository();
    private IUserService userService = new UserService();
    private IPhotoService photoService = new PhotoService();
    public async ValueTask<Response<PhotoCommentDto>> AddAsync(PhotoCommentCreationDto model)
    {
        var user = (await userService.GetByIdAsync(model.UserId)).Value;
        var photo = (await photoService.GetByIdAsync(model.PhotoId)).Value;
        if (user is null || photo is null)
            return new Response<PhotoCommentDto>
            {
                StatusCode = 404,
                Message = "Not found user or project"
            };

        var newEntity = new PhotoComment
        {
            CreatedAt = DateTime.Now,
            PhotoId = model.PhotoId,
            UserId = model.UserId,
            Text = model.Text
        };

        var insertedEntity = await photoCommentRepository.InsertAsync(newEntity);

        var mappedDto = new PhotoCommentDto
        {
            CreatedAt = insertedEntity.CreatedAt,
            Photo = photo,
            User = user,
            Id = insertedEntity.Id,
            Text = insertedEntity.Text
        };

        return new Response<PhotoCommentDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var existedEntity = await photoCommentRepository.SelectAsync(id);

        if (existedEntity is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        await photoCommentRepository.DeleteAsync(existedEntity.Id);

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<PhotoCommentDto>>> GetAllByPhotoIdAsync(long photoId)
    {
        var entities = photoCommentRepository.SelectAllAsync()
                            .Where(u => u.PhotoId == photoId).ToList();

        var mappedModels = new List<PhotoCommentDto>();

        foreach (var entity in entities)
        {
            mappedModels.Add(new PhotoCommentDto
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
                Photo = (await photoService.GetByIdAsync(entity.PhotoId)).Value,
                UpdatedAt = entity.UpdatedAt,
                User = (await userService.GetByIdAsync(entity.UserId)).Value,
                Text = entity.Text
            });
        }

        return new Response<List<PhotoCommentDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedModels
        };
    }

    public async ValueTask<Response<List<PhotoCommentDto>>> GetAllByUserIdAsync(long userId)
    {
        var entities = photoCommentRepository.SelectAllAsync()
                            .Where(u => u.UserId == userId).ToList();

        var mappedModels = new List<PhotoCommentDto>();

        foreach (var entity in entities)
        {
            mappedModels.Add(new PhotoCommentDto
            {
                CreatedAt = entity.CreatedAt,
                Id = entity.Id,
                Photo = (await photoService.GetByIdAsync(entity.PhotoId)).Value,
                UpdatedAt = entity.UpdatedAt,
                User = (await userService.GetByIdAsync(entity.UserId)).Value,
                Text = entity.Text
            });
        }

        return new Response<List<PhotoCommentDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedModels
        };
    }

    public async ValueTask<Response<PhotoCommentDto>> UpdateAsync(long id, string text)
    {
        var existedEntity = await photoCommentRepository.SelectAsync(id);

        if (existedEntity is null)
            return new Response<PhotoCommentDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        existedEntity.Text = text;

        var updatedEntity = await photoCommentRepository.UpdateAsync(existedEntity);

        var mappedDto = new PhotoCommentDto
        {
            Id = updatedEntity.Id,
            Text = updatedEntity.Text,
            CreatedAt = updatedEntity.CreatedAt,
            UpdatedAt = updatedEntity.UpdatedAt
        };

        return new Response<PhotoCommentDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }
}