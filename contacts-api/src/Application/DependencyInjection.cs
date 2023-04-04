using Application.Services;
using Application.Services.Contacts;
using AutoMapper;
using Domain.Interfaces.Services.Contacts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración AutoMapper
            var autoMapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(typeof(IMapperService).Assembly);
            });
            IMapper mapper = autoMapperConfig.CreateMapper();

            // Inyección de dependencias de servicios personalizados
            services.AddScoped<IGetAllContactService, GetAllContactService>();
            services.AddScoped<IMapperService, MapperService>();
            services.AddSingleton(mapper);

            return services;
        }
    }
}