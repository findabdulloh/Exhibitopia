using Exhibitopia2.Domain.Commons;
using Exhibitopia2.Domain.Entities;

namespace Exhibitopia2.Service.DTOs;

public class PhotoLikeDto : Auditable
{
    public UserDto User { get; set; }
    public PhotoDto Photo { get; set; }
}