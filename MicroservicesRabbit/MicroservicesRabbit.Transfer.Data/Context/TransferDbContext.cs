using Microsoft.EntityFrameworkCore;
using MicroservicesRabbit.Transfer.Domain.Models;

namespace MicroservicesRabbit.Transfer.Data.Context
{
	public class TransferDbContext : DbContext
	{
		public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
		{
		}

		public DbSet<TransferLog> TransferLogs { get; set; }
	}
}

