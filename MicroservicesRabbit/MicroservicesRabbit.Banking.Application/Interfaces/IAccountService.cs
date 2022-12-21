using System;
using MicroservicesRabbit.Banking.Application.Models;
using MicroservicesRabbit.Banking.Domain.Models;

namespace MicroservicesRabbit.Banking.Application.Interfaces
{
	public interface IAccountService
	{
		IEnumerable<Account> GetAccounts();
		void Transfer(AccountTransfer accountTransfer);
	}
}

