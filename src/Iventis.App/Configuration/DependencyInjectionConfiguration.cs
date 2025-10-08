using Iventis.App.Utils;
using Iventis.Domain.Interfaces.Repository;
using Iventis.Domain.Interfaces.Services;
using Iventis.Domain.Services;
using Iventis.Infrastructure.Repository;


namespace Iventis.App.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);

            // Services
            services.AddScoped<AuthenticationService>();
            services.AddScoped<IEntregadorService, EntregadorService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IMotoService, MotoService>();
            services.AddScoped<ICalculoLocacaoService, CalculoLocacaoService>();

            // Repository
            services.AddScoped<IEntregadorRepository,EntregadorRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
            services.AddScoped<IMotoRepository, MotoRepository>();
        }
    }
}
