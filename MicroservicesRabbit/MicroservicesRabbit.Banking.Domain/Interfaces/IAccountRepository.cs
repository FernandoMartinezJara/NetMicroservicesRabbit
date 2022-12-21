using System;
using MicroservicesRabbit.Banking.Domain.Models;

namespace MicroservicesRabbit.Banking.Domain.Interfaces
{
	public interface IAccountRepository
	{
		IEnumerable<Account> GetAccount();
	}
}

