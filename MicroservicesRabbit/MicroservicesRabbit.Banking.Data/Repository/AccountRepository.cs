using System;
using MicroservicesRabbit.Banking.Data.Context;
using MicroservicesRabbit.Banking.Domain.Interfaces;
using MicroservicesRabbit.Banking.Domain.Models;

namespace MicroservicesRabbit.Banking.Data.Repository
{
	public class AccountRepository : IAccountRepository
	{
        private BankingDbContext _context;

		public AccountRepository(BankingDbContext context)
		{
            _context = context;
		}

        public IEnumerable<Account> GetAccount()
        {
            return _context.Accounts;
        }
    }
}

