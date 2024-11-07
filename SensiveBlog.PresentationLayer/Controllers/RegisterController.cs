using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlog.EntityLayer.Concrete;
using SensiveBlog.PresentationLayer.Models;

namespace SensiveBlog.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;  //_userManager fieldı aracılığıyla UserManager sınıfına erişim sağlayacağız
        //constructor oluşturarak bizim yerimize newleme işlemi yapmasını sağladık
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
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName,
                ImageUrl = "test"
            };
            var result = await _userManager.CreateAsync(appUser, model.Password); //passwordü bu şekilde dışarıdan göndermemizin sebebi şifrenin şifrelenerek gidiyor 
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
