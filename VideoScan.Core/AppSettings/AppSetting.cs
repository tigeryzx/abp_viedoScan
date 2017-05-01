using Abp.Domain.Entities;
using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoScan.Settings
{
    public class AppSetting : Entity
    {
        public string SettingName { get; set; }

        public string SettingValue { get; set; }

    }
}
