using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace OGMC.Data.StartupExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static Task UseNopExceptionHandler(this IApplicationBuilder application)
        {
            //log errors
            application.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception == null)
                        return;

                    try
                    {
                        //log error
                        //await DependencyInjection.GetService<IActivityService>().InsertError(exception);
                    }
                    finally
                    {
                        //rethrow the exception to show the error page
                        ExceptionDispatchInfo.Throw(exception);
                    }
                });
            });
            return Task.CompletedTask;
        }
    }
}
