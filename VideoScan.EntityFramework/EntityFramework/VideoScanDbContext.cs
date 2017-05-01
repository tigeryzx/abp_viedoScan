using System.Data.Common;
using Abp.Zero.EntityFramework;
using VideoScan.Authorization.Roles;
using VideoScan.MultiTenancy;
using VideoScan.Users;
using VideoScan.Videos;
using System.Data.Entity;
using VideoScan.Favorites;
using VideoScan.ResDirs;
using VideoScan.Settings;

namespace VideoScan.EntityFramework
{
    public class VideoScanDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual IDbSet<Video> Videos { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
        public virtual IDbSet<Favorite> Favorites { get; set; }
        public virtual IDbSet<ResDir> ResDirs { get; set; }
        public virtual IDbSet<AppSetting> AppSetting { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public VideoScanDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in VideoScanDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of VideoScanDbContext since ABP automatically handles it.
         */
        public VideoScanDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public VideoScanDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public VideoScanDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
