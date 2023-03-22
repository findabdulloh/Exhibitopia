using Exhibitopia2.Data.Repositories;
using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;
using Exhibitopia2.Service.Interfaces;

namespace Exhibitopia2.Service.Services;

public class PhotoService : IPhotoService
{
    private IPhotoRepository photoRepository = new PhotoRepository();
    private IUserService userService = new UserService();

    public async ValueTask<Response<PhotoDto>> AddAsync(PhotoCreationDto model)
    {
        var mappedEntity = new Photo
        {
            AuthorId = model.AuthorId,
            CreatedAt = DateTime.Now,
            Name = model.Name,
            Privacy = model.Privacy,
            Description = model.Description,
            Category = model.Category
        };

        var insertedEntity = await photoRepository.InsertAsync(mappedEntity);

        var mappedDto = new PhotoDto
        {
            Description = insertedEntity.Description,
            Id = insertedEntity.Id,
            Name = insertedEntity.Name,
            Privacy = insertedEntity.Privacy,
            CreatedAt = insertedEntity.CreatedAt,
            Author = (await userService.GetByIdAsync(insertedEntity.AuthorId)).Value,
            Category = insertedEntity.Category
        };

        return new Response<PhotoDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var existingEntity = await photoRepository.SelectAsync(id);

        if (existingEntity is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = false
            };

        await photoRepository.DeleteAsync(existingEntity.Id);
        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<PhotoDto>>> GetAllAsync()
    {
        var entities = photoRepository.SelectAllAsync().ToList();
        var modelDtos = new List<PhotoDto>();

        foreach (var item in entities)
        {
            modelDtos.Add(new PhotoDto
            {
                Description = item.Description,
                Id = item.Id,
                Name = item.Name,
                Privacy = item.Privacy,
                CreatedAt = item.CreatedAt,
                Author = (await userService.GetByIdAsync(item.AuthorId)).Value,
                UpdatedAt = item.UpdatedAt,
                Category = item.Category,
            });
        }

        return new Response<List<PhotoDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = modelDtos
        };
    }

    public async ValueTask<Response<PhotoDto>> GetByIdAsync(long id)
    {
        var entity = await photoRepository.SelectAsync(id);

        if (entity is null)
            return new Response<PhotoDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        var mappedDto = new PhotoDto
        {
            Description = entity.Description,
            Id = entity.Id,
            Name = entity.Name,
            Privacy = entity.Privacy,
            CreatedAt = entity.CreatedAt,
            Author = (await userService.GetByIdAsync(entity.AuthorId)).Value,
            UpdatedAt = entity.UpdatedAt,
            Category = entity.Category,
        };

        return new Response<PhotoDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<PhotoDto>> UpdateAsync(long id, PhotoCreationDto model)
    {
        var existedEntity = await photoRepository.SelectAsync(id);

        if (existedEntity is null)
            return new Response<PhotoDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        existedEntity.AuthorId = model.AuthorId;
        existedEntity.Name = model.Name;
        existedEntity.Privacy = model.Privacy;
        existedEntity.Description = model.Description;
        existedEntity.UpdatedAt = DateTime.Now;
        
        var updatedEntity = await photoRepository.UpdateAsync(existedEntity);

        var mappedDto = new PhotoDto
        {
            Description = updatedEntity.Description,
            Id = updatedEntity.Id,
            Name = updatedEntity.Name,
            Privacy = updatedEntity.Privacy,
            CreatedAt = updatedEntity.CreatedAt,
            Author = (await userService.GetByIdAsync(updatedEntity.AuthorId)).Value,
            UpdatedAt = updatedEntity.CreatedAt,
            Category = updatedEntity.Category,
        };

        return new Response<PhotoDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }
}
