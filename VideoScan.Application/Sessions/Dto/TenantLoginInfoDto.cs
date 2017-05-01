using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using VideoScan.MultiTenancy;

namespace VideoScan.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}