using System;
using Microsoft.EntityFrameworkCore;
using MicroservicesRabbit.Banking.Domain.Models;

namespace MicroservicesRabbit.Banking.Data.Context
{
	public class BankingDbContext : DbContext
	{
		public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
		{

		}

		public DbSet<Account> Accounts { get; set; }
	}
}

 