using System.ComponentModel.DataAnnotations;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.MoneyTransfer
{
    public class MoneyTransferUpdateDto
    {   
        public int Id { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string? Notes { get; set; }
        public int OriginAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public int? GoalId { get; set; }
    }
}