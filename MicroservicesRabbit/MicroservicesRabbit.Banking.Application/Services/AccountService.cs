using MicroservicesRabbit.Banking.Application.Interfaces;
using MicroservicesRabbit.Banking.Application.Models;
using MicroservicesRabbit.Banking.Domain.Commands;
using MicroservicesRabbit.Banking.Domain.Interfaces;
using MicroservicesRabbit.Banking.Domain.Models;
using MicroservicesRabbit.Domain.Core.Bus;

namespace MicroservicesRabbit.Banking.Application.Services
{
	public class AccountService : IAccountService
	{
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _bus = eventBus;
		}

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccount();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount);

            _bus.SendCommand(createTransferCommand);
        }
    }
}

