using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.Dto.User;
using SecondBrain.Models.Entities;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {   
        private ApiResponse _response;
        private UserManager<ApplicationUser> _userManager;
        
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Your registration success logic
                return Ok(new { Message = "Registration successful" });
            }

            // If registration fails, return errors
            return BadRequest(new { Errors = result.Errors });
        }
    }
}