using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Dto.Subcategory;
using SecondBrain.Models.Enums;

namespace SecondBrain.Models.Dto.RecurringTransaction
{
    public class RecurringTransactionIndexDto
    {
        public string Description { get; set; }
        public int DayOfMonth { get; set; }
        public float Amount { get; set; }
        public bool Active { get; set; }
        public AccountDto Account { get; set; }
        public SubcategoryDto Subcategory { get; set; }
        public TransactionType Type { get; set; }
    }
}