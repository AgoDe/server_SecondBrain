using System.ComponentModel.DataAnnotations;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.MoneyTransfer
{
    public class MoneyTransferIndexDto
    {
        public string Description { get; set; }
         [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public AccountDto OriginDto { get; set; } = null!;
        public AccountDto DestinationAccount { get; set; } = null!;
    }
}