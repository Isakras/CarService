using Abp.Authorization;
using Invoice.Authorization.Roles;
using Invoice.Authorization.Users;

namespace Invoice.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
