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
using System.IO;

namespace VideoScan.Video
{
    public class VideoAppService : VideoScanAppServiceBase, IVideoAppService
    {
        private readonly IRepository<VideoScan.Videos.Video> _videoRepository;
        private readonly IRepository<VideoScan.Settings.AppSetting> _appSettingRepository;
        private readonly IRepository<VideoScan.ResDirs.ResDir> _resDirsRepository;
        private readonly IRepository<VideoScan.Videos.Image> _imageRespository;

        public VideoAppService(
            IRepository<VideoScan.Videos.Video> videoRepository,
            IRepository<VideoScan.Settings.AppSetting> appSettingRepository,
            IRepository<VideoScan.ResDirs.ResDir> resDirsRepository,
            IRepository<VideoScan.Videos.Image> imageRespository
            )
        {
            this._videoRepository = videoRepository;
            this._appSettingRepository = appSettingRepository;
            this._resDirsRepository = resDirsRepository;
            this._imageRespository = imageRespository;
        }

        public async Task<PagedResultDto<VideoListDto>> GetVideoPageList(VideoPageInput input)
        {
            PagedResultDto<VideoListDto> result = new PagedResultDto<VideoListDto>();
            List<VideoScan.Videos.Video> videoList = this._videoRepository.GetAll()
                .Where(x => !x.IsSkip)
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
                videoResult.CoverId = video.GetCoverId();
                videoResult.FtpUrl = ConvertFtpUrl(video.PhysicalPath);
                videoResultList.Add(videoResult);
            }

            result.TotalCount = this._videoRepository
                .GetAll()
                .Where(x => !x.IsSkip)
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
            videoResult.CoverId = video.GetCoverId();
            videoResult.FtpUrl = ConvertFtpUrl(video.PhysicalPath);

            return videoResult;
        }


        public async Task DelVideo(int videoId)
        {
            var video = await this._videoRepository.GetAsync(videoId);
            throw new NotImplementedException();
        }

        protected string _imageDir;

        protected string ConvertImagePath(string srcPath)
        {
            if (string.IsNullOrEmpty(this._imageDir))
            {
                var setting = this._appSettingRepository.Single(x => x.SettingName == "ImageDir");
                this._imageDir = setting.SettingValue;
            }

            return Path.Combine(this._imageDir, srcPath.Replace("/", "\\"));
        }

        protected string _ftpServer;

        protected string ConvertFtpUrl(string srcPath)
        {
            if (string.IsNullOrEmpty(this._ftpServer))
            {
                var setting = this._appSettingRepository.Single(x => x.SettingName == "FtpServer");
                this._ftpServer = setting.SettingValue;
            }
            var resDirInfo = this._resDirsRepository.Single(x => srcPath.StartsWith(x.DirName));
            var rpFtp = resDirInfo.DirName.Substring(0, resDirInfo.DirName.LastIndexOf("\\") + 1);
            return srcPath.Replace(rpFtp, this._ftpServer).Replace("\\", "/");
        }


        public async Task<string> GetImageRealPath(int imageId)
        {
            var imageInfo = await this._imageRespository.GetAsync(imageId);
            return ConvertImagePath(imageInfo.Path);
        }
    }
}
