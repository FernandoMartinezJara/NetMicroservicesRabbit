using MicroservicesRabbit.Transfer.Domain.Models;

namespace MicroservicesRabbit.Transfer.Domain.Interfaces
{
	public interface ITransferRepository
	{
		IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}

