using Invoice.Roles.Dto;
using System.Collections.Generic;

namespace Invoice.Web.Models.Roles;

public class RoleListViewModel
{
    public IReadOnlyList<PermissionDto> Permissions { get; set; }
}
