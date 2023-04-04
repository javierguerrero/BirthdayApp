using Domain.Interfaces.Repositories;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Inicializar EF Core por Inyección de Dependencias
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Inyección de depndencias de servicios personalizados
            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }
    }
}


