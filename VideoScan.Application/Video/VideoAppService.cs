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
            List<VideoScan.Videos.Video> videoList = this._videoRepository.GetAll()
                .WhereIf(input.FavId.HasValue, x => x.Favorite.Any(y => y.Id == input.FavId))
                .OrderByDescending(x => x.AppendDate)
                .PageBy(input)
                .ToList();

            List<VideoListDto> videoResultList = new List<VideoListDto>();
            result.Items = videoResultList;

            foreach (var video in videoList)
            {
                var videoResult = video.MapTo<VideoListDto>();
                videoResult.IsFavorite = video.GetFavoriteStatus(this.AbpSession.UserId.Value);
                videoResult.CoverPath = video.GetCoverPath();
                videoResultList.Add(videoResult);
            }

            result.TotalCount = this._videoRepository
                .GetAll()
                .WhereIf(input.FavId.HasValue, x => x.Favorite.Any(y => y.Id == input.FavId))
                .Count();

            return await Task.FromResult<PagedResultDto<VideoListDto>>(result);
        }


        public async Task<bool> GetVideoFavStatus(int videoId)
        {
            return await Task.FromResult<bool>(this._videoRepository
                .Count(x => x.Id == videoId && x.Favorite.Any(y => y.User_Id == this.AbpSession.UserId)) > 0);
        }


        public async Task SetVideoCover(int videoId, int imgId)
        {
            var video = await this._videoRepository.GetAsync(videoId);
            foreach (var item in video.Images)
            {
                if (item.Id == imgId)
                    item.IsCover = true;
                else
                    item.IsCover = false;
            }
        }


        public async Task<VideoListDto> GetVideoInfo(int videoId)
        {
            var video = await this._videoRepository.GetAsync(videoId);

            var videoResult = video.MapTo<VideoListDto>();
            videoResult.IsFavorite = video.GetFavoriteStatus(this.AbpSession.UserId.Value);
            videoResult.CoverPath = video.GetCoverPath();

            return videoResult;
        }


        public async Task DelVideo(int videoId)
        {
            var video = await this._videoRepository.GetAsync(videoId);
            throw new NotImplementedException();
        }
    }
}
