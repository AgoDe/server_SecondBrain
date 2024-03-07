using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Enums;

namespace SecondBrain.Models.Dto.RecurringTransaction
{
    public class RecurringTransactionUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DayOfMonth { get; set; }
        public float Amount { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public int AccountId { get; set; }
        public int SubcategoryId { get; set; }
        public TransactionType Type { get; set; }
    }
}