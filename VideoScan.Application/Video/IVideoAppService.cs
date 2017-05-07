using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoScan.Video.Dto;

namespace VideoScan.Video
{
    public interface IVideoAppService : IApplicationService
    {
        Task<PagedResultDto<VideoListDto>> GetVideoPageList(VideoPageInput input);

        Task<bool> GetVideoFavStatus(int videoId);

        Task SetVideoCover(int videoId, int imgId);

        Task<VideoListDto> GetVideoInfo(int videoId);

        Task DelVideo(int videoId);

        Task<string> GetImageRealPath(int imageId);
    }
}
