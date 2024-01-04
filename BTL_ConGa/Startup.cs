using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BTL_ConGa
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

    }
}
