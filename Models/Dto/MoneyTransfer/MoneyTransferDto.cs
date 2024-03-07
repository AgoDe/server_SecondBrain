using System.ComponentModel.DataAnnotations;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Dto.Goal;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.MoneyTransfer
{
    public class MoneyTransferDto
    {
        public string Description { get; set; }
         [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Notes { get; set; }
        public AccountDto OriginDto { get; set; } = null!;
        public AccountDto DestinationAccount { get; set; } = null!;
        public GoalDto Goal { get; set; } = null!;
    }
}