using Invoice.Roles.Dto;
using System.Collections.Generic;

namespace Invoice.Web.Models.Users;

public class UserListViewModel
{
    public IReadOnlyList<RoleDto> Roles { get; set; }
}
