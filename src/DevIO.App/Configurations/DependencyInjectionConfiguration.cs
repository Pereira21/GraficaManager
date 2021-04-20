using DevIO.Business.Interfaces;
using DevIO.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IMateriaPrimaEstoqueAppService, MateriaPrimaEstoqueAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();

            return services;
        }
    }
}
