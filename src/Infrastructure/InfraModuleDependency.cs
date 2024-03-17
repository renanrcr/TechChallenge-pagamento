using Domain.Adapters;
using Domain.Adapters.MercadoPagoQrCode;
using Domain.Adapters.RabbitMQ;
using Infrastructure.RabbitMQ;
using Infrastructure.Repositories;
using Infrastructure.Repositories.MercadoPagoQrCode;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfraModuleDependency
    {
        public static void AddInfraModule(this IServiceCollection services)
        {
            services.AddScoped<IMercadoPagoRequestRepository, MercadoPagoRequestRepository>();
            services.AddScoped<IQrCodePedidoRepository, QrCodePedidoRepository>();
            services.AddScoped<IConnectionFactory, ConnectionFactoryCreator>();
            services.AddScoped<IMessageServiceRepository, MessageServiceRepository>();
            services.AddScoped<IRabbitPublish, RabbitPublish>();
            services.AddHostedService<RabbitConsumer>();
        }
    }
}