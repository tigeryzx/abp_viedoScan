using Abp.Domain.Entities;
using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.ResDirs
{
    public class ResDir : Entity
    {
        /// <summary>
        /// 资源目录名称
        /// </summary>
        public string DirName { get; set; }
    }
}
