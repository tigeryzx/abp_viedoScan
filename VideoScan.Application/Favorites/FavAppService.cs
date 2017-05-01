using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using VideoScan.Favorites.Dto;
using Abp.Domain.Repositories;

namespace VideoScan.Favorites
{
    public class FavAppService : VideoScanAppServiceBase, IFavAppService
    {
        private readonly IRepository<Favorite> _favoriteRepository;

        public FavAppService(IRepository<Favorite> favoriteRepository)
        {
            this._favoriteRepository = favoriteRepository;
        }

        public async Task CreateFav(Dto.CreateFavInpute input)
        {
            var fav = input.MapTo<Favorite>();
            await this._favoriteRepository.InsertAsync(fav);
        }

        public Task<ListResultDto<FavListDto>> GetFavList()
        {
            throw new NotImplementedException();
        }

        public Task DelFav(long favId)
        {
            throw new NotImplementedException();
        }
    }
}
