using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Favorites
{
    public interface IFavManager : IDomainService
    {
        Task<List<Favorite>> GetAllFavByUserId(long userId);
    }
}
