using Iventis.App.Utils;
using Iventis.Domain.Services;


namespace Iventis.App.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {

            // AutoMapper
            services.AddAutoMapper(typeof(AutoMappingProfile));

            // Services
            services.AddScoped<AuthenticationService>();

        }
    }
}
