using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondBrain.Models.Dto.User
{
    public class RegistrationRequestDto
    {
        public string Email {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Password {get; set;}
    }
}