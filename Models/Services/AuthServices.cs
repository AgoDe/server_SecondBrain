using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Services
{
    public class AuthService
    {
        private IConfiguration _configuration { get; set; }
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // TODO: deve diventare privato
        public string GenerateJwtToken(ApplicationUser user)
        {
            SymmetricSecurityKey securityKey = new(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new []
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            JwtSecurityToken token = new(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}