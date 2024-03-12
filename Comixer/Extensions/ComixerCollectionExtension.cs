using AutoMapper;
using Comixer.Core.Extensions;
using Comixer.Infrastructure;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ComixerCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AutoMapperConfiguration(services);
            services.AddScoped<IRepository, Repository>();

            return services;
        }

        private static void AutoMapperConfiguration(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new(mc => mc.AddProfile<ApplicationMappingProfile>());
            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
