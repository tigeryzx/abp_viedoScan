using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace VideoScan.EntityFramework.Repositories
{
    public abstract class VideoScanRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<VideoScanDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected VideoScanRepositoryBase(IDbContextProvider<VideoScanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class VideoScanRepositoryBase<TEntity> : VideoScanRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected VideoScanRepositoryBase(IDbContextProvider<VideoScanDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
