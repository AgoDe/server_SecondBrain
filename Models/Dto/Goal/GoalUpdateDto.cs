using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.Goal
{
    public class GoalUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Initial_Amount { get; set; }
        public float Target { get; set; }
        public int AccountId { get; set; }
    }
}