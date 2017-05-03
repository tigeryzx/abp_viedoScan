using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Video.Dto
{
    public class VideoPageInput : PagedResultRequestDto
    {
        public int? FavId { get; set; }
    }
}
