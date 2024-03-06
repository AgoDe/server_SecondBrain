using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.Models.Entities
{
    public class MoneyTransfer : Entity
    {
        public string Description { get; set; }
         [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Notes { get; set; }
        public int OriginAccountId { get; set; }
        public Account OriginAccount { get; set; } = null!;
        public int DestinationAccountId { get; set; }
        public Account DestinationAccount { get; set; } = null!;
        public int GoalId { get; set; }
        public Goal Goal { get; set; } = null!;
    }
}