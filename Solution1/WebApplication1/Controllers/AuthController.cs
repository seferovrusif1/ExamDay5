using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.ViewModels.AuthVMs;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        //TODO:RESULT ERRORLARI FORECH ILE SUMMRY E ELAVE ET
        IConfiguration _configuration { get; }
        UserManager<AppUser> _userManager { get; }
        SignInManager<AppUser> _signinManager { get; }
        RoleManager<IdentityRole> _roleManager { get; }
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            AppUser user = new AppUser
            {
                FullName = vm.FullName,
                UserName = vm.Username,
                Email = vm.Email
            };
            var result =await _userManager.CreateAsync(user, vm.Password);
            if(!result.Succeeded) 
            {

                return View(vm);
            }
            var roleresult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleresult.Succeeded)
            {
                return View(vm);
            }
            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) 
            {
                return View(vm);
            }
            AppUser user;
            if (vm.UsernameOrEmail.Contains("@"))
            {
                user= await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user= await _userManager.FindByNameAsync(vm.UsernameOrEmail);

            }
            if (user == null)
            {
                ModelState.AddModelError("", "UserNotFound");
                return View(vm);
            }

            var result=await _signinManager.CheckPasswordSignInAsync(user, vm.Password, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserNotFound");
                return View(vm);
            }
            await _signinManager.SignInAsync(user, true);
            return RedirectToAction(nameof(Index),"Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction(nameof(Login),"Auth");
        }

        public async Task<bool> CreateInitial()
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    var result =await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
                    if (!result.Succeeded) { return false; }
                }
            }
            if(await _userManager.FindByEmailAsync("Admin@gmail.com")==null && await _userManager.FindByNameAsync("Admin") == null)
            {
                AppUser user = new AppUser
                {
                    FullName = "Admin",
                    UserName = "Admin",
                    Email = Convert.ToString(_configuration["Admin:Email"])
                };
                var result = await _userManager.CreateAsync(user, "Admin123");
                if (!result.Succeeded)
                {
                    return false;
                }
                var roleresult = await _userManager.AddToRoleAsync(user, "Admin");
                if (!roleresult.Succeeded)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
