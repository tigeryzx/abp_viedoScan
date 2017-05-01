using System.Threading.Tasks;
using Abp.Application.Services;
using VideoScan.Roles.Dto;

namespace VideoScan.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
