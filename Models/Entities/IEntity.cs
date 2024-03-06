using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Constraints;

namespace SecondBrain.Models.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt {get;}
        public DateTime RowVersion { get; }
        public string? Status { get; }

    }
}