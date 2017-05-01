using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace VideoScan.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : VideoScanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}