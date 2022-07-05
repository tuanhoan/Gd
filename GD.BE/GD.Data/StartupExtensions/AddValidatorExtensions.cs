using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GD.Data.StartupExtensions
{
    public static class AddValidatorExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IValidator<User>, TestValidator>();
            return services;
        }
    }
}
