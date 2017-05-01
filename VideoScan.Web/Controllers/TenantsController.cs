using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using VideoScan.Authorization;
using VideoScan.MultiTenancy;

namespace VideoScan.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : VideoScanControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}