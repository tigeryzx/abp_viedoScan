using Abp.Web.Mvc.Views;

namespace VideoScan.Web.Views
{
    public abstract class VideoScanWebViewPageBase : VideoScanWebViewPageBase<dynamic>
    {

    }

    public abstract class VideoScanWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected VideoScanWebViewPageBase()
        {
            LocalizationSourceName = VideoScanConsts.LocalizationSourceName;
        }
    }
}