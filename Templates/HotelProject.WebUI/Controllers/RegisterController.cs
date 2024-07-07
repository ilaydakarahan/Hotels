using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ResultAppUserDto> _userManager;

        public RegisterController(UserManager<ResultAppUserDto> userManager)
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
            var appUser = new ResultAppUserDto()
            {
                Name = appUserDto.Name,
                Surname = appUserDto.Surname,
                City    = appUserDto.City,
                Email = appUserDto.Email,
                UserName = appUserDto.UserName
            };
            var result = await _userManager.CreateAsync(appUser, appUserDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
