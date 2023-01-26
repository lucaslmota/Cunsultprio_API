using ConsultorioManager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ConsultorioWebAPI.Configuration
{
    public static class UseFluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            services.AddControllers()
                        .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                        .AddFluentValidation(p =>
                        {
                            p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                            p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                            p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                        });

            #pragma warning restore CS0618 // O tipo ou membro é obsoleto
        }
    }
}
