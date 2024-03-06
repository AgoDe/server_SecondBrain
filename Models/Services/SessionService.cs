using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SecondBrain.Data;
using SecondBrain.Models.Entities;

namespace SecondBrain.Models.Services
{
    public class SessionService
    {
        private readonly ApplicationDbContext _db;
        private string _secretKey;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private IMapper _mapper;

        public SessionService(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _db = db;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        
        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }


    }

}