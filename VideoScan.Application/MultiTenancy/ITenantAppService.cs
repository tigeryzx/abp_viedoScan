using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using VideoScan.MultiTenancy.Dto;

namespace VideoScan.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
