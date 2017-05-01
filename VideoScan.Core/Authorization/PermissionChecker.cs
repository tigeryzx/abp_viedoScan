using Abp.Authorization;
using VideoScan.Authorization.Roles;
using VideoScan.MultiTenancy;
using VideoScan.Users;

namespace VideoScan.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
