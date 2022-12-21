using MicroservicesRabbit.Domain.Core.Bus;
using MicroservicesRabbit.Transfer.Domain.Events;
using MicroservicesRabbit.Transfer.Domain.Interfaces;
using MicroservicesRabbit.Transfer.Domain.Models;

namespace MicroservicesRabbit.Transfer.Domain.EventHandlers
{
	public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
	{
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        //public TransferEventHandler()
        //{

        //}

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}

