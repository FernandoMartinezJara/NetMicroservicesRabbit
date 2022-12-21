using MediatR;
using MicroservicesRabbit.Banking.Domain.Commands;
using MicroservicesRabbit.Banking.Domain.Events;
using MicroservicesRabbit.Domain.Core.Bus;

namespace MicroservicesRabbit.Banking.Domain.ComandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //publish event rabbitMQ
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}

