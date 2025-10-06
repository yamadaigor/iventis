using Iventis.Domain.Interfaces.Services;
using Iventis.Domain.Services;

namespace Iventis.App.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {
            // Services
            services.AddScoped<AuthenticationService>();

        }
    }
}
