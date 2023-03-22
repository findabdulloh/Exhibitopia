using Exhibitopia2.Domain.Commons;
using Exhibitopia2.Domain.Enums;

namespace Exhibitopia2.Service.DTOs;

public class UserDto : Auditable
{
    public string Fullname { get; set; }
    public string Bio { get; set; }
    public string Username { get; set; }
    public UserRoles Role { get; set; }
}
