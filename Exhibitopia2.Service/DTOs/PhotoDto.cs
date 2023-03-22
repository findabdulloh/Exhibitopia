using Exhibitopia2.Domain.Commons;
using Exhibitopia2.Domain.Entities;
using Exhibitopia2.Domain.Enums;

namespace Exhibitopia2.Service.DTOs;

public class PhotoDto : Auditable
{
    public UserDto Author { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PrivacyTypes Privacy { get; set; }
    public PhotoCategories Category { get; set; }
}
