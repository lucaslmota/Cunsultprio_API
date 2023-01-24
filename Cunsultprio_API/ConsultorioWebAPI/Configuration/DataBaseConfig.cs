using ConsultorioData.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultorioWebAPI.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConsultorioContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConsulConnection")));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ConsultorioContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
