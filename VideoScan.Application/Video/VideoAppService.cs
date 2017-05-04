using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoScan.Video.Dto;
using Abp.Linq.Extensions;
using Abp.AutoMapper;

namespace VideoScan.Video
{
    public class VideoAppService : VideoScanAppServiceBase, IVideoAppService
    {
        private readonly IRepository<VideoScan.Videos.Video> _videoRepository;

        public VideoAppService(
            IRepository<VideoScan.Videos.Video> videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        public async Task<PagedResultDto<VideoListDto>> GetVideoPageList(VideoPageInput input)
        {
            PagedResultDto<VideoListDto> result = new PagedResultDto<VideoListDto>();
            result.Items = this._videoRepository.GetAll()
                .WhereIf(input.FavId.HasValue, x => x.Favorite.Any(y => y.Id == input.FavId))
                .OrderByDescending(x => x.AppendDate)
                .PageBy(input)
                .ToList().MapTo<List<VideoListDto>>();

            result.TotalCount = this._videoRepository
                .GetAll()
                .WhereIf(input.FavId.HasValue, x => x.Favorite.Any(y => y.Id == input.FavId))
                .Count();

            return await Task.FromResult<PagedResultDto<VideoListDto>>(result);
        }


        public async Task<bool> GetVideFavStatus(int id)
        {
            return await Task.FromResult<bool>(this._videoRepository
                .Count(x => x.Favorite.Any(y => y.User_Id == this.AbpSession.UserId)) > 0);
        }
    }
}
