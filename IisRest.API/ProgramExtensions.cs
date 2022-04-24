using IisRest.Contracts.Repositories;
using IisRest.Contracts.Services;
using IisRest.Data.Db.MsSql.Configuration;
using IisRest.Data.Db.MsSql.Repositories;
using IisRest.Services.BoughtAssetService;
using IisRest.Services.SoldAssetService;
using Microsoft.EntityFrameworkCore;

namespace IisRest.API
{
    internal static class ProgramExtensions
    {
        internal static void ConfigureAutoMapper(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        internal static void ConfigureDependecyInjection(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISoldAssetService, SoldAssetService>();
            services.AddScoped<IBoughtAssetService, BoughtAssetService>();
        }

        internal static void ConfigureDatabase(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(
                    configuration.GetConnectionString("IIS-CS"),
                    opt => opt.MigrationsAssembly("IisRest.Data.Db.MsSql"));
            });
        }
    }
}
