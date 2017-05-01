using VideoScan.EntityFramework;
using EntityFramework.DynamicFilters;

namespace VideoScan.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly VideoScanDbContext _context;

        public InitialHostDbBuilder(VideoScanDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
