using System.ComponentModel.DataAnnotations;
using SecondBrain.Models.Enums;

namespace SecondBrain.Models.Entities
{
    public class ExpectedTransaction : Entity
    {
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 
        public int DayOfMonth { get; set; }
        public float Amount { get; set; }
        public string? Notes { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; } = null!;

        public TransactionType Type { get; set; }
    }
}