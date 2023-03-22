using Exhibitopia2.Domain.Commons;

namespace Exhibitopia2.Domain.Entities;

public class PhotoComment : Auditable
{
    public string? Text { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long PhotoId { get; set; }
    public Photo Photo { get; set; }
}
