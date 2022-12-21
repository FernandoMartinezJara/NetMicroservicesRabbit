using MicroservicesRabbit.Domain.Core.Events;

namespace MicroservicesRabbit.Domain.Core.Commands
{
	public abstract class Command : Message
	{
		public DateTime Timestamp { get; protected set; }

		protected Command()
		{
			Timestamp = DateTime.Now;
		}
	}
}

