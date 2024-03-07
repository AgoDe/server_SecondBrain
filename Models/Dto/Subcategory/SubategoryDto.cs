using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Dto.Category;
using SecondBrain.Models.Dto.User;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Dto.Subcategory
{
    public class SubcategoryDto
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Slug { get; set; }
        public float MontlhyBudget { get; set; }
        public CategoryDto Category { get; set; }
    }
}