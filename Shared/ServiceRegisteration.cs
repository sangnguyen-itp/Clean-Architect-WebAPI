using Application.Interfaces.Common;
using Infrastructures.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructures.Shared
{
    public static class ServiceRegisteration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDatetimeService, DatetimeService>();
            services.AddTransient<IEncryptionService, EncryptionService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisServiceURL");
            });
        }
    }
}
