using HotelProject.EntityLayer;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ResultAppUserDto appUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = appUserDto.Name,
                Surname = appUserDto.Surname,
                City = appUserDto.City,
                Email = appUserDto.Email,
                UserName = appUserDto.UserName
            };
            if (appUserDto.Password == appUserDto.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, appUserDto.Password);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
