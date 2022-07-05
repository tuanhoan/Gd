using GD.Data.Services;
using GD.Data.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GD.Data.EFService;
using GD.Metadata;
using GD.Entity.Responsitories;

namespace GD.Data.StartupExtensions
{
    public static class AddServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IQueryService, QueryService>();
            services.AddTransient<IService, Service>();
            services.AddDbContext<GDContext>(options =>
            {
                options.UseSqlServer(
               configuration.GetConnectionString("TasksDbContext"),
               x => x.MigrationsAssembly("TaskApi.Entity"));
            });
            
            services.AddTransient<IBulkOperation, SqlServerBulkOperation>();
            return services;
        }
    }
}
