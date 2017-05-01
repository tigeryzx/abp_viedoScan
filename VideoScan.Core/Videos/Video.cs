using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoScan.Favorites;

namespace VideoScan.Videos
{
    public class Video : Entity
    {
        /// <summary>
        /// 截图信息
        /// </summary>
        public virtual ICollection<Image> Images { get; set; }

        /// <summary>
        /// 收藏信息
        /// </summary>
        public virtual ICollection<Favorite> Favorite { get; set; }

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
        /// 忽略的视频
        /// </summary>
        public bool IsSkip { get; set; }
    }
}
