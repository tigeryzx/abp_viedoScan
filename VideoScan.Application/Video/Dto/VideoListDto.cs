using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Video.Dto
{
    public class VideoListDto : EntityDto
    {
        /// <summary>
        /// 截图信息
        /// </summary>
        public List<ImageDto> Images { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 物理路径
        /// </summary>
        public string PhysicalPath { get; set; }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AppendDate { get; set; }

        /// <summary>
        /// 是否喜爱
        /// </summary>
        public bool IsFavorite { get; set; }

        /// <summary>
        /// 封面路径
        /// </summary>
        public string CoverPath { get; set; }
    }
}
