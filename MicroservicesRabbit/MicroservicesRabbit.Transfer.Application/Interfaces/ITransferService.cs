
using MicroservicesRabbit.Transfer.Domain.Models;

namespace MicroservicesRabbit.Transfer.Application.Interfaces
{
	public interface ITransferService
	{
		IEnumerable<TransferLog> GetTransferLogs();
	}
}

