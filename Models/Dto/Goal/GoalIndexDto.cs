using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.Goal
{
    public class GoalIndexDto
    {
        public string Description { get; set; }
        public float Target { get; set; }
        public AccountDto Account { get; set; }
    }

}