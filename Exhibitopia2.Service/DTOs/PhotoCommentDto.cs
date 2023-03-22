using Exhibitopia2.Domain.Commons;
using Exhibitopia2.Domain.Entities;

namespace Exhibitopia2.Service.DTOs;

public class PhotoCommentDto : Auditable
{
    public string Text { get; set; }
    public UserDto User { get; set; }
    public PhotoDto Photo { get; set; }
}
