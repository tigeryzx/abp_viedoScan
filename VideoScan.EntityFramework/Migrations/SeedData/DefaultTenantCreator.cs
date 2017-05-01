using System.Linq;
using VideoScan.EntityFramework;
using VideoScan.MultiTenancy;

namespace VideoScan.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly VideoScanDbContext _context;

        public DefaultTenantCreator(VideoScanDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
