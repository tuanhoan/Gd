using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GD.Entity.Responsitories;
using GD.SDK.Data.EFService;
using GD.SDK.Metadata;
using GD.Data.Services.Interface;
using GD.Data.Services;

namespace GD.Data.StartupExtensions
{
    public static class AddServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IQueryService, QueryService>();
            services.AddTransient<IChangeService, ChangeService>();
            services.AddDbContext<GDContext>(options =>
            {
               options.UseSqlServer(
               configuration.GetConnectionString("GDContext"),
               x => x.MigrationsAssembly("GD.Entity"));
            });
            
            services.AddTransient<IBulkOperation, SqlServerBulkOperation>();
            return services;
        }
    }
}
