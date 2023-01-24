using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace ConsultorioWebAPI.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "ConsultorioWebAPI", 
                        Version = "v1",
                        Description = "API da palicação consultório.",
                        Contact = new OpenApiContact
                        {
                            Name= "Lucas Lima Mota",
                            Email ="lucaslmota0431@gmail.com",
                            Url = new Uri("https://github.com/lucaslmota/Cunsultprio_API")
                        },
                        License = new OpenApiLicense
                        {
                            Name= "OSD",
                            Url = new Uri("https://opensource.org.osd")
                        },
                        TermsOfService = new Uri("https://opensource.org.osd")

                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddFluentValidationRulesToSwagger();
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "ConsultorioWebAPI v1");
            });
        }
    }
}
