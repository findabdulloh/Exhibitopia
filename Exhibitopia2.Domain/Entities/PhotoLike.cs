using Exhibitopia2.Domain.Commons;

namespace Exhibitopia2.Domain.Entities;

public class PhotoLike : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long PhotoId { get; set; }
    public Photo Photo { get; set; }
}
