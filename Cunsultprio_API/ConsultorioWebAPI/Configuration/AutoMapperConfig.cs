using ConsultorioManager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultorioWebAPI.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMap), typeof(AlterarClienteMap), typeof(NovoMedicoMappingProfile));
        }
    }
}
