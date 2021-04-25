using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using DevIO.Business.Services;
using DevIO.Data.Data;
using DevIO.Data.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.App.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<GraficaDbContext>();

            #region Repositories

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMateriaPrimaEstoqueRepository, MateriaPrimaEstoqueRepository>();

            #endregion

            #region Services

            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IMateriaPrimaEstoqueAppService, MateriaPrimaEstoqueAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();

            #endregion

            return services;
        }
    }
}
