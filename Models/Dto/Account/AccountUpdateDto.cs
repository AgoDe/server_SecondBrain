using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondBrain.Models.Dto.Account
{
    public class AccountUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float InitialBalance { get; set; }
        public int UserId { get; set; }
    }
}