using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoScan.Favorites.Dto;

namespace VideoScan.Favorites
{
    public interface IFavAppService : IApplicationService
    {
        Task CreateFav(CreateFavInpute input);

        Task<ListResultDto<FavListDto>> GetCurrentFavList();

        Task DelFav(int favId);

        Task FavVideo(int favId, int videoId);
    }
}
