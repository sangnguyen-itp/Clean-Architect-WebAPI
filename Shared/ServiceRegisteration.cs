using Application.Interfaces.Common;
using Infrastructures.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructures.Shared
{
    public static class ServiceRegisteration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDatetimeService, DatetimeService>();
        }
    }
}
