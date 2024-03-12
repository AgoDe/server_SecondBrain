using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SecondBrain.Models.Dto.User;

namespace SecondBrain.Models.Dto.Auth
{
    public class LoginResponseDto
    {
        public UserDto User {get; set;}
        public string Token {get; set;}
        public DateTime Expire {get; set;}
        public HttpStatusCode Status {get; set;}
        public string Message {get; set;}
    }
}