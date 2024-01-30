﻿using TechChallenge.src.Adapters.Driven.Infra.DataContext;
using TechChallenge.src.Adapters.Driven.Infra.Repositories;
using TechChallenge.src.Adapters.Driving.Api.WebHooks;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Adapters.Driven.Infra
{
    public static class InfraModuleDependency
    {
        public static void AddInfraModule(this IServiceCollection services)
        {
            services.AddScoped<DataBaseContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddSingleton<IReceiveWebhook, ConsoleWebhookReceiver>();
        }
    }
}