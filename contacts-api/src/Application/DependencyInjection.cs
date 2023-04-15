using Application.Services;
using AutoMapper;
using Domain.Interfaces.Services;
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
            services.AddSingleton(mapper);
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<IGetAllContactService, GetAllContactService>();
            services.AddScoped<IGetContactService, GetContactService>();
            services.AddScoped<ICreateContactService, CreateContactService>();
            services.AddScoped<IDeleteContactService, DeleteContactService>();

            return services;
        }
    }
}