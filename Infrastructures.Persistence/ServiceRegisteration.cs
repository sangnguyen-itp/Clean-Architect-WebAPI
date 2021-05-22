using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructures.Persistence.Context;
using Infrastructures.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructures.Persistence
{
    public static class ServiceRegisteration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            #region Repositories
            services.AddTransient(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            #endregion
        }
    }
}
