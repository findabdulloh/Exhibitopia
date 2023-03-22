using Exhibitopia2.Data.Repositories;
using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Domain.Enums;
using Exhibitopia2.Service.DTOs;
using Exhibitopia2.Service.Helpers;
using Exhibitopia2.Service.Interfaces;

namespace Exhibitopia2.Service.Services;

public class UserService : IUserService
{
    private IUserRepository userRepository = new UserRepository();

    public async ValueTask<Response<UserDto>> AddAsync(UserCreationDto model)
    {
        var existingEntity = userRepository.SelectAllAsync()
            .Where(u => u.Username == model.Username).Take(1).ToList();

        if (existingEntity.Any())
            return new Response<UserDto>
            {
                StatusCode = 400,
                Message = "Username is already taken"
            };

        var mappedEntity = new User
        {
            Username = model.Username,
            Bio = model.Bio,
            CreatedAt = DateTime.Now,
            Password = model.Password,
            Fullname = model.Fullname,
            Role = UserRoles.User
        };

        var insertedEntity = await userRepository.InsertAsync(mappedEntity);

        var mappedDto = new UserDto
        {
            Username = insertedEntity.Username,
            Bio = insertedEntity.Bio,
            CreatedAt = insertedEntity.CreatedAt,
            UpdatedAt = insertedEntity.UpdatedAt,
            Role = insertedEntity.Role,
            Fullname = insertedEntity.Fullname,
            Id = insertedEntity.Id
        };

        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var existingEntity = await userRepository.SelectAsync(id);

        if (existingEntity is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = false
            };

        await userRepository.DeleteAsync(id);

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<UserDto>>> GetAllAsync()
    {
        var entities = userRepository.SelectAllAsync().ToList();
        var modelDtos = new List<UserDto>();

        foreach (var item in entities)
        {
            modelDtos.Add(new UserDto
            {
                Username = item.Username,
                Bio = item.Bio,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt,
                Role = item.Role,
                Fullname = item.Fullname,
                Id = item.Id
            });
        }

        return new Response<List<UserDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = modelDtos
        };
    }

    public async ValueTask<Response<UserDto>> GetByIdAsync(long id)
    {
        var entity = await userRepository.SelectAsync(id);

        if (entity is null)
            return new Response<UserDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        var mappedDto = new UserDto
        {
            Username = entity.Username,
            Bio = entity.Bio,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Role = entity.Role,
            Fullname = entity.Fullname,
            Id = entity.Id
        };

        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<UserDto>> LoginAsync(string username, string password)
    {
        var entity = userRepository.SelectAllAsync()
            .Where(u => u.Username == username && u.Password == password).ToList().FirstOrDefault();

        if (entity is null)
            return new Response<UserDto>
            {
                StatusCode = 400,
                Message = "Username or password was incorrect"
            };

        var mappedDto = new UserDto
        {
            Username = username,
            Bio = entity.Bio,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Fullname = entity.Fullname,
            Role = entity.Role,
            Id = entity.Id
        };

        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }

    public async ValueTask<Response<UserDto>> UpdateAsync(long id, UserCreationDto model)
    {
        var existedEntity = await userRepository.SelectAsync(id);

        if (existedEntity is null)
            return new Response<UserDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };

        existedEntity.Username = model.Username;
        existedEntity.Bio = model.Bio;
        existedEntity.Password = model.Password;
        existedEntity.Fullname = model.Fullname;
        existedEntity.UpdatedAt = DateTime.Now;

        var updatedEntity = await userRepository.UpdateAsync(existedEntity);

        var mappedDto = new UserDto
        {
            Username = updatedEntity.Username,
            Bio = updatedEntity.Bio,
            CreatedAt = updatedEntity.CreatedAt,
            UpdatedAt = updatedEntity.UpdatedAt,
            Role = updatedEntity.Role,
            Fullname = updatedEntity.Fullname,
            Id = updatedEntity.Id
        };

        return new Response<UserDto>
        {
            StatusCode = 200,
            Message = "Success",
            Value = mappedDto
        };
    }
}
