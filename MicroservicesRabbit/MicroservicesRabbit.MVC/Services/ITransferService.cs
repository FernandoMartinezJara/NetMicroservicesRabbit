using MicroservicesRabbit.MVC.Models.DTO;

namespace MicroservicesRabbit.MVC.Services
{
	public interface ITransferService
	{
        Task Transfer(TransferDto transferDto);
    }
}

