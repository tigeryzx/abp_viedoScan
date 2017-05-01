using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Favorites.Dto
{
    [AutoMap(typeof(Favorite))]
    public class CreateFavInpute
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
