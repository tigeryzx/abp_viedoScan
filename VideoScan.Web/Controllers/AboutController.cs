using System.Web.Mvc;

namespace VideoScan.Web.Controllers
{
    public class AboutController : VideoScanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}