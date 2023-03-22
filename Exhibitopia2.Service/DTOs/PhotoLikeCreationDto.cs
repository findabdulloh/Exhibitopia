using Exhibitopia2.Domain.Entities;

namespace Exhibitopia2.Service.DTOs;

public class PhotoLikeCreationDto
{
    public long UserId { get; set; }
    public long PhotoId { get; set; }
}