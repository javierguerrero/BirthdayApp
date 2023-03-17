using Application.Contacts;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) => {

        // Inicializar EF Core por Inyecci�n de Dependencias
        var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

        // Inyecci�n de depndencias de servicios personalizados
        services.AddTransient<IContactService, ContactService>();
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<INotifier, Notifier>();
    })
    .Build();

host.Run();
