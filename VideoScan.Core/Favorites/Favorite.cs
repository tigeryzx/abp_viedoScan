﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoScan.Users;
using VideoScan.Videos;

namespace VideoScan.Favorites
{
    public class Favorite : Entity
    {
        public string CategoryName { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}