using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseManagementService.Domain.Interfaces;
using WarehouseManagementService.Infra.Data.Data;
using WarehouseManagementService.Infra.Data.Repository;
using WarehouseManagementService.Infra.Data.UnitOfWork;

namespace WarehouseManagementService.Infra.IOC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString, v => v.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IRepository, Repository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}