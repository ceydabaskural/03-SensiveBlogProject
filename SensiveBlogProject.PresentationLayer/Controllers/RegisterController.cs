using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensiveBlogProject.EntityLayer.Concrete;
using SensiveBlogProject.PresentationLayer.Models;

namespace SensiveBlogProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        //sadece bu sınıftan erişilebilsin diye private readonly yaptık ve _userManager field aracılığıyla UserManager içindeki proplara erişebileceğiz
        private readonly UserManager<AppUser> _userManager;


        //Constructor metot sayesinde newleme işlemine gerek kalmıyor, otomatik olarak gerçekleştiriyor.
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
                //kullanıcıdan almak istediğimiz parametreleri yazıyoruz
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Name,
                ImageUrl = "test"

            };
            //passwordu dışarıdan göndermemizin sebebi, şifrenin şifrelenerek(hashlenerek) kaydolmasından kaynaklı:
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //asp-validation-summary ile index kısmında bu hataları yazdırdık
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
        }
    }
}
