using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models.Dto.Auth;
using SecondBrain.Models.Dto.User;
using SecondBrain.Models.Entities;
using SecondBrain.Models.Services;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private AuthService _authServices;

        public AuthController(ILogger<AuthController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AuthService authService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _authServices = authService;
        }

        [HttpPost("login")]
        public async Task<LoginResponseDto> Login([FromBody] LoginRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new LoginResponseDto()
                {
                    Status = HttpStatusCode.NotFound,
                    Message = "Utente non trovato"
                };
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new LoginResponseDto()
                {
                    User = new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    },
                    Token = _authServices.GenerateJwtToken(user),
                    Expire = DateTime.Now.AddDays(5),
                    Status = HttpStatusCode.OK
                };
            }
            else
            {
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return new LoginResponseDto()
                    {
                        Status = HttpStatusCode.Locked,
                        Message = "User account locked out."

                    };
                }
                return new LoginResponseDto()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Credenziali invalide"
                };
            }

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