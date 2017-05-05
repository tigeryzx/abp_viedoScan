using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Favorites.Dto
{
    public class FavListDto : EntityDto
    {
        public string CategoryName { get; set; }

        public int Count { get; set; }
    }
}
