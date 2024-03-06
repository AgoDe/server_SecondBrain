using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondBrain.Models.Entities
{
    public class Goal : Entity
    {
        public string Description { get; set; }
        public float Initial_Amount { get; set; }
        public float Target { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}