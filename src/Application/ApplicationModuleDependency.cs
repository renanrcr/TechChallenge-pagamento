using Domain.Adapters;
using Domain.Notificacoes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}