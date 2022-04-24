using System.Text;
using IisRest.Contracts.Auth;
using IisRest.Contracts.Entities;
using IisRest.Contracts.Repositories;
using IisRest.Contracts.Services;
using IisRest.Contracts.Settings;
using IisRest.Data.Db.MsSql.Configuration;
using IisRest.Data.Db.MsSql.Repositories;
using IisRest.Services.AuthService;
using IisRest.Services.BoughtAssetService;
using IisRest.Services.SoldAssetService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace IisRest.API
{
    internal static class ProgramExtensions
    {
        internal static void LoadSettingsFromConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(
                configuration.GetSection("JWTSettings"));
        }

        internal static void ConfigureAutoMapper(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        internal static void ConfigureDependecyInjection(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISoldAssetService, SoldAssetService>();
            services.AddScoped<IBoughtAssetService, BoughtAssetService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
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

        internal static void ConfigureIdentityServer(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddIdentity<UserProfile, IdentityRole<int>>(opt =>
            {
                opt.Password.RequiredLength = 4;
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
        }

        internal static void ConfigureAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWTSettings:Audience"],
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])),
                };
            });
        }
    }
}
