using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Domain.Enums;

namespace Exhibitopia2.Service.DTOs;

public class PhotoCommentCreationDto
{
    public string Text { get; set; }
    public long UserId { get; set; }
    public long PhotoId { get; set; }
}