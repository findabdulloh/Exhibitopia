using Exhibitopia2.Domain.Commons;
using Exhibitopia2.Domain.Enums;

namespace Exhibitopia2.Domain.Entities;

public class Photo : Auditable
{
    public long AuthorId { get; set; }
    public User Author { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public PrivacyTypes Privacy { get; set; }
    public PhotoCategories Category { get; set; }
}
