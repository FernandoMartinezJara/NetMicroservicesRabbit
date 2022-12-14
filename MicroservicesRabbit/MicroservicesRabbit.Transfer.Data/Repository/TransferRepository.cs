using MicroservicesRabbit.Transfer.Data.Context;
using MicroservicesRabbit.Transfer.Domain.Interfaces;
using MicroservicesRabbit.Transfer.Domain.Models;

namespace MicroservicesRabbit.Transfer.Data.Repository
{
	public class TransferRepository : ITransferRepository
	{
        private TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }

        public void Add(TransferLog transferLog)
        {
            _context.TransferLogs.Add(transferLog);
            _context.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }
    }
}

