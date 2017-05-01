using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Videos
{
    public class Image : Entity
    {
        public virtual Video Video { get; set; }

        public string Path { get; set; }

        public bool IsCover { get; set; }

        public bool IsStoryCascade { get; set; }

        public int OrderCode { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
