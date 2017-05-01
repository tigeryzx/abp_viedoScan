using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using VideoScan.EntityFramework;

namespace VideoScan.Migrator
{
    [DependsOn(typeof(VideoScanDataModule))]
    public class VideoScanMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<VideoScanDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}