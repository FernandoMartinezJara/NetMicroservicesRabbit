using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MicroservicesRabbit.Domain.Core.Bus;
using MicroservicesRabbit.Infra.Bus;
using MicroservicesRabbit.Transfer.Data.Context;
using MicroservicesRabbit.Transfer.Application.Interfaces;
using MicroservicesRabbit.Transfer.Application.Services;
using MicroservicesRabbit.Transfer.Domain.Interfaces;
using MicroservicesRabbit.Transfer.Data.Repository;
using MicroservicesRabbit.Transfer.Domain.Events;
using MicroservicesRabbit.Transfer.Domain.EventHandlers;
using MicroservicesRabbit.Banking.Domain.ComandHandlers;
using MicroservicesRabbit.Banking.Domain.Commands;
using Microsoft.Extensions.Configuration;

namespace MicroservicesRabbit.Infra.IoC
{
    public class TransferDependencyContainer
    {
		public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
            //Domain Bus

            //services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, configuration);
            });

            services.AddTransient<TransferEventHandler>();

            //Domain Event
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<TransferDbContext>();

        }

	}
}

