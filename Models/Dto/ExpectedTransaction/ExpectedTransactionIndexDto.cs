using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Dto.Subcategory;
using SecondBrain.Models.Enums;

namespace SecondBrain.Models.Dto.ExpectedTransaction
{
    public class ExpectedTransactionIndexDto
    {
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public AccountDto Account { get; set; }
        public SubcategoryDto Subcategory { get; set; }
        public TransactionType Type { get; set; }
    }
}