using ConsultorioManager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultorioWebAPI.Configuration
{
    public static class UseFluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            services.AddControllers()
                        .AddFluentValidation(p =>
                        {
                            p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                            p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                        });

            #pragma warning restore CS0618 // O tipo ou membro é obsoleto
        }
    }
}
