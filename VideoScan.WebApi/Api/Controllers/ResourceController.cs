using Abp.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VideoScan.Video;

namespace VideoScan.Api.Controllers
{
    public class ResourceController : AbpApiController
    {
        private IVideoAppService _videoAppService;

        public ResourceController(IVideoAppService videoAppService)
        {
            this._videoAppService = videoAppService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetImage(int imageId)
        {
            string realPath = await this._videoAppService.GetImageRealPath(imageId);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(File.ReadAllBytes(realPath));　　//data为二进制图片数据
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return response;
        }
    }
}
