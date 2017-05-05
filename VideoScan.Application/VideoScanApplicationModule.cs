using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using VideoScan.Video.Dto;
using VideoScan.Favorites.Dto;

namespace VideoScan
{
    [DependsOn(typeof(VideoScanCoreModule), typeof(AbpAutoMapperModule))]
    public class VideoScanApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()

                mapper.CreateMap<VideoScan.Videos.Video, VideoListDto>()
                    .ForMember(x => x.CoverPath, options => options.Ignore())
                    .ForMember(x => x.IsFavorite, options => options.Ignore());

                mapper.CreateMap<VideoScan.Favorites.Favorite, FavListDto>()
                    .ForMember(x => x.Count, options => options.MapFrom(x => x.GetVideoCount()));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
