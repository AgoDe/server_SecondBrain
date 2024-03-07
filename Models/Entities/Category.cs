using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slugify;

namespace SecondBrain.Models.Entities
{
    public class Category : Entity
    {
        private readonly SlugHelper _slugify;
        private string _name;

        public Category()
        {
            _slugify = new SlugHelper();
        }

        public string Name 
        { 
            get => _name;
            set 
            {
                _name = value;
                Slug = _slugify.GenerateSlug(value);    
            } 
        }
        public string Slug { get; set; }
        public string? Color { get; set; }
        public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}