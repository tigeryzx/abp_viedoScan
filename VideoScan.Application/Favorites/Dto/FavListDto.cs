using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Favorites.Dto
{
    [AutoMapFrom(typeof(Favorite))]
    public class FavListDto : EntityDto<long>
    {
        public string CategoryName { get; set; }
    }
}
