using ConsultorioManager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ConsultorioWebAPI.Configuration
{
    public static class UseFluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            services.AddControllers()
                        .AddNewtonsoftJson(x =>
                        {
                            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                            x.SerializerSettings.Converters.Add(new StringEnumConverter());                         
                        })
                        .AddJsonOptions(x =>
                        {
                            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        })
                
                        .AddFluentValidation(p =>
                        {
                            p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                            p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                            p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                            p.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
                        });

            #pragma warning restore CS0618 // O tipo ou membro é obsoleto
        }
    }
}
