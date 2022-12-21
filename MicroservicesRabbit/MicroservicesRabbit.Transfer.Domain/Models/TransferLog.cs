using System;
namespace MicroservicesRabbit.Transfer.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }

        public int FromAccount { get; set; }

        public decimal ToAccount { get; set; }

        public decimal TransferAmount { get; set; }

    }
}

