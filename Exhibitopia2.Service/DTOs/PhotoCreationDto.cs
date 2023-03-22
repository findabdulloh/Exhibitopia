using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Domain.Enums;

namespace Exhibitopia2.Service.DTOs;

public class PhotoCreationDto
{
    public long AuthorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PrivacyTypes Privacy { get; set; }
    public PhotoCategories Category { get; set; }
}
