using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Entities;
using SecondBrain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SecondBrain.Models.Entities
{
    public class RecurringTransaction : Entity
    {
        public string Description { get; set; }
        public int DayOfMonth { get; set; }
        public float Amount { get; set; }
        public bool Active { get; set; }
        public string? Notes { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; } = null!;
        public TransactionType Type { get; set; }
    }
}