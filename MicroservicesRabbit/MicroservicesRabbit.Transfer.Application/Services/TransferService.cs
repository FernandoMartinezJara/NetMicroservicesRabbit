using MicroservicesRabbit.Transfer.Application.Interfaces;
using MicroservicesRabbit.Transfer.Domain.Models;
using MicroservicesRabbit.Domain.Core.Bus;
using MicroservicesRabbit.Transfer.Domain.Interfaces;

namespace MicroservicesRabbit.Transfer.Application.Services
{
	public class TransferService : ITransferService
	{
        private readonly IEventBus _bus;
        private readonly ITransferRepository _transferRepository;

        public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
        {
            _transferRepository = transferRepository;
            _bus = eventBus;
		}

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}

