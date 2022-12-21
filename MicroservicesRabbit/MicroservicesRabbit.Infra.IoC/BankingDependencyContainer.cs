using System;
using MediatR;
using MicroservicesRabbit.Banking.Application.Interfaces;
using MicroservicesRabbit.Banking.Application.Services;
using MicroservicesRabbit.Banking.Data.Context;
using MicroservicesRabbit.Banking.Data.Repository;
using MicroservicesRabbit.Banking.Domain.ComandHandlers;
using MicroservicesRabbit.Banking.Domain.Commands;
using MicroservicesRabbit.Banking.Domain.Interfaces;
using MicroservicesRabbit.Domain.Core.Bus;
using MicroservicesRabbit.Infra.Bus;
using MicroservicesRabbit.Transfer.Domain.EventHandlers;
using MicroservicesRabbit.Transfer.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesRabbit.Infra.IoC
{
	public class BankingDependencyContainer
	{
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus

            services.AddTransient<IEventBus, RabbitMQBus>();

            //services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            //    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            //});

            //DomainBanking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

        }
    }
}

