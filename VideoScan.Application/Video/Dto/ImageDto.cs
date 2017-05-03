using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VideoScan.Video.Dto
{
    [AutoMapFrom(typeof(VideoScan.Videos.Image))]
    public class ImageDto : EntityDto
    {
        public string Path { get; set; }

        public bool IsCover { get; set; }

        public bool IsStoryCascade { get; set; }

        public int OrderCode { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
