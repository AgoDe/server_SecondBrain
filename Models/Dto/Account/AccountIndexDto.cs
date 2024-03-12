using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.Account
{
    public class AccountIndexDto
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Slug { get; set; }

    }
}