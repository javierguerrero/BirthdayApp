using Application.Contacts;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) => {

        // Inicializar EF Core por Inyección de Dependencias
        var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

        // Inyección de depndencias de servicios personalizados
        services.AddTransient<IContactService, ContactService>();
    })
    .Build();

host.Run();
