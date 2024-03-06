using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Constraints;

namespace SecondBrain.Models.Entities
{
    public class Entity : IEntity
    {
        public Entity()
        {
            CreatedAt = DateTime.Now;
            RowVersion = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt {get; private set;}
        public DateTime RowVersion { get; set; }
        public string? Status { get; set; }

    }
}