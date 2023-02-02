using ConsultorioData.Repository;
using ConsultorioManager.Implementations;
using ConsultorioManager.Interfaces;
using ConsultorioManager.InterfacesManager;
using ConsultorioManager.InterfacesRepository;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultorioWebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoManager, MedicoManager>();

        }
    }
}
