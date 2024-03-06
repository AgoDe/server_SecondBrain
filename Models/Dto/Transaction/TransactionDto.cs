using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Enums;

namespace SecondBrain.Models.Dto.Transaction
{
    public class TransactionDto
    {
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Notes { get; set; }
        public TransactionType Type { get; set; }
    }
}