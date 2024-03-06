using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SecondBrain.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {   

        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Display(Name = "Cognome")]
        public string LastName { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();
     
    }
    
}