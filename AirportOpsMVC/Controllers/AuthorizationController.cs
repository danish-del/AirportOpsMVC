using AirportOpsMVC.Implementation;
using AirportOpsMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AirportOpsMVC.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtService jwtService;
        public AuthorizationController(UserManager<AppUser> UserManager, SignInManager<AppUser> signInManager,
            JwtService JwtService)
        {
            _userManager = UserManager;
            _signInManager = signInManager;
            jwtService = JwtService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username,string email,string password)
        {
            var user = new AppUser
            {
                UserName = username,
                Email = email
            };
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var entity = await _userManager.FindByEmailAsync(email);
            if(entity == null)
            {
                return Unauthorized();
            }
            var res = await _signInManager.CheckPasswordSignInAsync(entity, password, false);
            if(!res.Succeeded)
            {
                return Unauthorized();
            }
            var token = jwtService.GenerateToken(entity);
            return Ok(new
            {
                message = "Login Successfull",
                token = token
            });
                
        }
    }
}
