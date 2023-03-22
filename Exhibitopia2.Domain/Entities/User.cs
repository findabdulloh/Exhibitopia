using Exhibitopia2.Domain.Commons;
using Exhibitopia2.Domain.Enums;

namespace Exhibitopia2.Domain.Entities;

public class User : Auditable
{
    public string Fullname { get; set; }
    public string? Bio { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRoles Role { get; set; }
}
