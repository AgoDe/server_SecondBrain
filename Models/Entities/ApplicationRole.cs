using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SecondBrain.Models.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {   
        [Display(Name = "Descrizione (opzionale)"),]
        [MaxLength(255, ErrorMessage = "La descrizione è troppo lunga")]
        public string? Description { get; set; }

        [Display(Name = "Permessi")]
        public ICollection<IdentityRoleClaim<int>>? RoleClaims { get; set; }

        [Display(Name = "Utenti")]
        public ICollection<ApplicationUser>? Users { get; set; }
    }
}