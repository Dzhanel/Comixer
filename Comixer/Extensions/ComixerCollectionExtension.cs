using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Extensions;
using Comixer.Core.Service;
using Comixer.Infrastructure.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ComixerCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AutoMapperConfiguration(services);
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IComicService, ComicsService>();

            return services;
        }

        private static void AutoMapperConfiguration(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = 
                new(mc => mc.AddProfile<ApplicationMappingProfile>());
            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
