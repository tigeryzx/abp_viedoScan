using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Favorites
{
    public class FavManager : DomainService, IFavManager
    {
        private readonly IRepository<Favorite> _favoriteRepository;

        public FavManager(
            IRepository<Favorite> favoriteRepository)
        {
            this._favoriteRepository = favoriteRepository;
        }

        public Task<List<Favorite>> GetAllFavByUserId(long userId)
        {
            return Task.FromResult<List<Favorite>>(this._favoriteRepository.GetAll()
                .Where(x => x.User.Id == userId)
                .ToList());
        }
    }
}
