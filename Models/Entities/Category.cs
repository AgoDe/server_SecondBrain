using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondBrain.Models.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string? Color { get; set; }
        public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}