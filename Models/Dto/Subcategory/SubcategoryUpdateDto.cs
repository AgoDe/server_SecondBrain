using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Dto.Category;
using SecondBrain.Models.Dto.User;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.Subcategory
{
    public class SubcategoryUpdateDto
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public float? MonthlyBudget { get; set; }
        public int CategoryId { get; set; }
    }
}