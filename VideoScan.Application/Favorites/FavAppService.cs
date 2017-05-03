using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using VideoScan.Favorites.Dto;
using Abp.Domain.Repositories;
using VideoScan.Users;

namespace VideoScan.Favorites
{
    public class FavAppService : VideoScanAppServiceBase, IFavAppService
    {
        private readonly IRepository<Favorite> _favoriteRepository;
        private readonly IRepository<VideoScan.Videos.Video> _videoRepository;
        private readonly IFavManager _favManager;
        private readonly IRepository<User, long> _userRepository;

        public FavAppService(
            IRepository<Favorite> favoriteRepository,
            IRepository<User, long> userRepository,
            IRepository<VideoScan.Videos.Video> videoRepository,
            IFavManager favManager)
        {
            this._favoriteRepository = favoriteRepository;
            this._userRepository = userRepository;
            this._favManager = favManager;
            this._videoRepository = videoRepository;
        }

        public async Task CreateFav(CreateFavInpute input)
        {
            var fav = input.MapTo<Favorite>();
            var user = await this._userRepository.GetAsync(AbpSession.UserId.Value);
            fav.User = user;
            await this._favoriteRepository.InsertAsync(fav);
        }

        public async Task<ListResultDto<FavListDto>> GetCurrentFavList()
        {
            var result = new ListResultDto<FavListDto>();
            result.Items = (await this._favManager.GetAllFavByUserId(base.AbpSession.UserId.Value)).MapTo<List<FavListDto>>();
            return result;
        }

        public async Task DelFav(int favId)
        {
            await this._favoriteRepository.DeleteAsync(favId);
        }

        public async Task FavVideo(int favId, int videoId)
        {
            var fav = await this._favoriteRepository.GetAsync(favId);
            var video = await this._videoRepository.GetAsync(videoId);
            fav.AddFavVideo(video);
        }
    }
}
