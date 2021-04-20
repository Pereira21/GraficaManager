using DevIO.Business.Interfaces;
using DevIO.Business.Services;
using DevIO.Data.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            #endregion
            #region Services
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IMateriaPrimaEstoqueAppService, MateriaPrimaEstoqueAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();
            #endregion

            return services;
        }
    }
}
