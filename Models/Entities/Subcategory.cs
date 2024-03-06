using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondBrain.Models.Entities
{
    public class Subcategory : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public float? MontlhyBudget { get; set; } = 0;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}